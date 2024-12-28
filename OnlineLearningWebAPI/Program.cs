using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Configurations;
using Microsoft.AspNetCore.Identity;
using OnlineLearningWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetValue<string>("CorsSettings:AllowedOrigins");

// Accept CORS API REACT
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Config Swagger UI
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer <token>').",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Config DBContext
builder.Services.AddDbContext<OnlineLearningDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging(false));

// Add DI for Secret Key JwtToken
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

// config Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// Add Authorize
builder.Services.AddAuthorizeConfig(builder.Configuration);

builder.Services.AddIdentity<Account, IdentityRole>()
    .AddEntityFrameworkStores<OnlineLearningDbContext>()
    .AddDefaultTokenProviders();

// Add Service Scope
//builder.Services.AddScoped<IRepository<Account>, AccountRepository>();
//builder.Services.AddScoped<IAccountService, AccountService>();
//builder.Services.AddScoped<ITeacherService, TeacherSerivce>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseRouting();

// Middleware Authentication v� Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map Controllers
app.MapControllers();

app.Run();
