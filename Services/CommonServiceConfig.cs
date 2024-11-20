using Microsoft.Extensions.DependencyInjection;
using Services.Common;
using Services.Common.Class;
using Services.Common.IClass;
using Services.Demo.Class;
using Services.Demo.IClass;
using Services.Login.Class;
using Services.Login.IClass;
using Services.Settings.Class;
using Services.Settings.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
