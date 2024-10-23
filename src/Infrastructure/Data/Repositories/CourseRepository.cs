using Application.Interfaces;
using CourseManagement.Domain.Entities;

namespace Infrastructure.Data.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly CourseManagementDbContext _context;

    public CourseRepository(CourseManagementDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Course course, CancellationToken cancellationToken = default)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync(cancellationToken);
        return course.Id;
    }
}
