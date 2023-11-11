

using Application.UnitOfWork;
using Domain.Interface;

namespace API.Extension;

public static class AplicationServicesExtensions
{

    
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
        });
    });
    
    
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
}


