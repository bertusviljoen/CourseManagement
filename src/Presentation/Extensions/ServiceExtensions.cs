using Microsoft.OpenApi.Models;

namespace Presentation.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Course Management API", Version = "v1" });
        });

        return services;
    }
}
