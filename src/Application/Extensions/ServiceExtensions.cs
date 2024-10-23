using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Courses.Commands;

namespace Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly));

        return services;
    }
}
