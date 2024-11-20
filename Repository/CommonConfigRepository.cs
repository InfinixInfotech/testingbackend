using Microsoft.Extensions.DependencyInjection;
using Repository.Common;
using Repository.Demo.Class;
using Repository.Demo.IClass;
using Repository.Login.Class;
using Repository.Login.IClass;
using Repository.Settings.Class;
using Repository.Settings.IClass;

namespace Repository
{
    public class CommonConfigRepository
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MongoDbRepository>();
            services.AddScoped<IDemoRepository, DemoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupsRepository, GroupsRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<ISegmentRepository, SegmentRepository>();
            services.AddScoped<ISegmentPlanRepository, SegmentPlanRepository>();
            services.AddScoped<ILeadSourceRepository, LeadSourceRepository>();
            services.AddScoped<ILeadStatusRepository, LeadStatusRepository>();

        }

    }
}
