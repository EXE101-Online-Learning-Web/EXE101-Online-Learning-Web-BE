using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Configurations
{
    public static class ServiceScopeConfig
    {
        public static IServiceCollection AddServiceScopeConfig(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Profile>, Repository.Repository<Profile>>();
            services.AddScoped<IRepository<Account>, Repository.Repository<Account>>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }
    }
}
