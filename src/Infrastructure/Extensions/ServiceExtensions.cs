using Application.Interfaces;
using CourseManagement.Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Interceptors;
using Infrastructure.Data.Repositories;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DispatchDomainEventsInterceptor>();
        services.AddScoped<AuditableEntityInterceptor>();

        services.AddSingleton(TimeProvider.System);
        services.AddScoped<IUser, CurrentUser>();

        services.AddDbContext<CourseManagementDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            options.AddInterceptors(
                sp.GetRequiredService<DispatchDomainEventsInterceptor>(),
                sp.GetRequiredService<AuditableEntityInterceptor>()
            );
        });

        services.AddScoped<ICourseRepository, CourseRepository>();

        return services;
    }
}
