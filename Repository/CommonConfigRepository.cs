using Microsoft.Extensions.DependencyInjection;
using Repository.Common;
using Repository.Demo.Class;
using Repository.Demo.IClass;
using Repository.Login;
using Repository.Login.Class;
using Repository.Login.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommonConfigRepository
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MongoDbRepository>();
            services.AddScoped<IDemoRepository, DemoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}
