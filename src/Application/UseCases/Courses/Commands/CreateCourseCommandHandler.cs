using CourseManagement.Domain.Events;
using CourseManagement.Domain.Entities;
using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Courses.Commands;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            MaxStudents = request.MaxStudents,
            IsActive = request.IsActive,
            CreatedUtc = DateTime.UtcNow,
            LastModifiedUtc = DateTime.UtcNow
        };

        course.AddDomainEvent(new CourseCreatedEvent(course));

        return await _courseRepository.CreateAsync(course, cancellationToken);
    }
}
