using Domain.Entities;

namespace Application.Interfaces;

public interface ICourseRepository
{
    Task<int> CreateAsync(Course course, CancellationToken cancellationToken = default);
}
