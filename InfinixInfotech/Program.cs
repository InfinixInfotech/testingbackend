using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Repository;
using Services;
using Services.Common.IClass;
using System.Text;
using Common;
using Models.Common;

var builder = WebApplication.CreateBuilder(args);

// Configure services
CommonServiceConfig.ConfigureServices(builder.Services);
CommonConfigRepository.ConfigureServices(builder.Services);
builder.Services.AddControllers();

// Add scoped services
builder.Services.AddScoped<JwtAcessToken>();
builder.Services.AddScoped<SequenceGenerator>();

// Configure MongoDB
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    var mongoSettings = serviceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(mongoSettings.ConnectionString);
});

// Configure JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("JWT Key is not configured. Please set it in the configuration.");
}

var key = Encoding.UTF8.GetBytes(jwtKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false, // Set to true if you want to validate the issuer
        ValidateAudience = false, // Set to true if you want to validate the audience
    };
});

// Configure Authorization
builder.Services.AddAuthorization(options =>
{
    // Define the "admin" policy
    options.AddPolicy("admin", policy =>
      policy.RequireRole("admin"));

    // Define the "AdminOrUser" policy
    options.AddPolicy("AdminOrUser", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("admin") || context.User.IsInRole("user")));

    // Define the "user" policy (to resolve the error)
    options.AddPolicy("user", policy =>
        policy.RequireRole("user"));
});

// Configure Distributed Cache (Memory Cache)
builder.Services.AddDistributedMemoryCache();

// Configure Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(12); // Session timeout
    options.Cookie.HttpOnly = true;             // Secure session cookie
    options.Cookie.IsEssential = true;          // For GDPR compliance
});

// Add HTTP Context Accessor
builder.Services.AddHttpContextAccessor();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


// Configure Swagger/OpenAPI with JWT support
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.\r\n\r\n" +
                      "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                      "Example: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable session middleware
app.UseSession(); // Ensure this is before any middleware that depends on session

// Enable CORS
app.UseCors("AllowSpecificOrigin");

// Enable authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Custom middleware to handle unauthorized access
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 401) // Unauthorized
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync("{\"error\": \"Unauthorized access\"}");
    }
});

// Map controllers to route requests
app.MapControllers();

// Run the application
app.Run();
