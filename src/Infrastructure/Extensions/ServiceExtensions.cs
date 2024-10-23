using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CourseManagementDbContext>((sp, options) =>
        {
            var mediator = sp.GetService<IMediator>();
            if (mediator == null)
            {
                throw new InvalidOperationException(
                    "IMediator not found. Please ensure you call AddApplicationServices() before AddInfrastructureServices()");
            }

            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<CourseManagementDbContext>((sp) =>
        {
            var options = sp.GetRequiredService<DbContextOptions<CourseManagementDbContext>>();
            var mediator = sp.GetRequiredService<IMediator>();
            return new CourseManagementDbContext(options, mediator);
        });

        services.AddScoped<ICourseRepository, CourseRepository>();

        return services;
    }
}
