using MediatR;

namespace Application.UseCases.Courses.Commands;

public record CreateCourseCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public int MaxStudents { get; init; }
    public bool IsActive { get; init; }
}
