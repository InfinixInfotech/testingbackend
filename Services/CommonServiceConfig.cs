using Microsoft.Extensions.DependencyInjection;
using Services.Common;
using Services.Common.Class;
using Services.Common.IClass;
using Services.Demo.Class;
using Services.Demo.IClass;
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
        }
    }
}
