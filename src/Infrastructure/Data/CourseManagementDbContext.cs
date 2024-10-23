using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class CourseManagementDbContext : DbContext
{
    public CourseManagementDbContext(DbContextOptions<CourseManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseManagementDbContext).Assembly);
    }
}
