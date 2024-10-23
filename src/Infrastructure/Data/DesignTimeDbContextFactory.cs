using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CourseManagementDbContext>
{
    public CourseManagementDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<DesignTimeDbContextFactory>()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<CourseManagementDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        // Create a mock IMediator since this is only used for design-time operations
        var mediator = new Mock<IMediator>().Object;

        return new CourseManagementDbContext(optionsBuilder.Options, mediator);
    }
}
