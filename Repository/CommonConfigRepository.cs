using Microsoft.Extensions.DependencyInjection;
using Repository.BulkLead.Class;
using Repository.BulkLead.IClass;
using Repository.Common;
using Repository.Demo.Class;
using Repository.Demo.IClass;
using Repository.Leads.Class;
using Repository.Leads.IClass;
using Repository.Login.Class;
using Repository.Login.IClass;
using Repository.Mail.Class;
using Repository.Mail.IClass;
using Repository.PR.Class;
using Repository.PR.IClass;
using Repository.Settings.Class;
using Repository.Settings.IClass;
using Repository.SO.Class;
using Repository.SO.IClass;

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
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IPaymentRaiseRepository, PaymentRaiseRepository>();
            services.AddScoped<IIdentifierService, IdentifierService>();
            services.AddScoped<ISORepository, SORepository>();
            services.AddScoped<ISMSRepository, SMSRepository>();
            services.AddScoped<IBulkLeadRepository, BulkLeadRepository>();


        }

    }
}
