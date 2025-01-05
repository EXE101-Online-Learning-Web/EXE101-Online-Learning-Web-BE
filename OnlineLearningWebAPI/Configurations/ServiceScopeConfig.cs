using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Configurations
{
    public static class ServiceScopeConfig
    {
        public static IServiceCollection AddServiceScopeConfig(this IServiceCollection services)
        {
            // Add Repository Scope
            //builder.Services.AddScoped<IRepository<Account>, AccountRepository>();

            services.AddScoped<IRepository<Profile>, Repository.Repository<Profile>>();
            services.AddScoped<IRepository<Account>, Repository.Repository<Account>>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();

            // Add Service Scope
            //builder.Services.AddScoped<IAccountService, AccountService>();
            //builder.Services.AddScoped<ITeacherService, TeacherSerivce>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IProfileService, ProfileService>();

            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseCategoryService, CourseCategoryService>();

            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
