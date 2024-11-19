using Microsoft.Extensions.DependencyInjection;
using Services.Common;
using Services.Common.Class;
using Services.Common.IClass;
using Services.Demo.Class;
using Services.Demo.IClass;
using Services.Login.Class;
using Services.Login.IClass;

namespace Services
{
    public static class CommonServiceConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
           services.AddScoped<Security>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IDemoService, DemoService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
