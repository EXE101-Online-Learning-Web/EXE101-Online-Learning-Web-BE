using OnlineLearningWebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Config DTO Scope
builder.Services.AddDtoScopeConfig(builder);
// Config Repository Scope
builder.Services.AddRepositoryScopeConfig();
// Config Service Scope
builder.Services.AddServiceScopeConfig();

// config Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// Add Authorize
builder.Services.AddAuthorizeConfig(builder.Configuration);

//Config Swagger UI
builder.Services.AddSwaggerConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// Middleware Authentication và Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map Controllers
app.MapControllers();

app.Run();
