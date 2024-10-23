using CourseManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class CourseManagementDbContext(DbContextOptions<CourseManagementDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseManagementDbContext).Assembly);
    }
}
