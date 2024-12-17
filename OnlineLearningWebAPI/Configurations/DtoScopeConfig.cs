using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.DTOs.request.EmailRequest;

namespace OnlineLearningWebAPI.Configurations
{
    public static class DtoScopeConfig
    {
        public static IServiceCollection AddDtoScopeConfig(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<OnlineLearningDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging(false));

            services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

            services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            return services;
        }
    }
}
