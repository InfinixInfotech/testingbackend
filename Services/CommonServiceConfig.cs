using Microsoft.Extensions.DependencyInjection;
using Services.Common;
using Services.Common.Class;
using Services.Common.IClass;
using Services.Demo.Class;
using Services.Demo.IClass;
using Services.Leads.Class;
using Services.Leads.IClass;
using Services.Login.Class;
using Services.Login.IClass;
using Services.Mail.Class;
using Services.Mail.IClass;
using Services.PR.Class;
using Services.PR.IClass;
using Services.Settings.Class;
using Services.Settings.IClass;
using Services.SO.Class;
using Services.SO.IClass;

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
            services.AddScoped<IGroupsService, GroupsService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IQualificationService, QualificationService>();
            services.AddScoped<ISegmentService, SegmentService>();
            services.AddScoped<ISegmentPlanService, SegmentPlanService>();
            services.AddScoped<ILeadSourceService, LeadSourceService>();
            services.AddScoped<ILeadStatusService, LeadStatusService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<IPaymentRaiseService, PaymentRaiseService>();
            services.AddScoped<ISOService, SOService>();
            services.AddScoped<ISMSService, SMSService>();
        }
    }
}
