using OnlineLearningWebAPI.Service;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Configurations
{
    public static class ServiceScopeConfig
    {
        public static IServiceCollection AddServiceScopeConfig(this IServiceCollection services)
        {
            // Add Service Scope
            //builder.Services.AddScoped<IRepository<Account>, AccountRepository>();
            //builder.Services.AddScoped<IAccountService, AccountService>();
            //builder.Services.AddScoped<ITeacherService, TeacherService>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }
    }
}
