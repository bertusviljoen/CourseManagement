using CourseManagement.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CourseManagement.Application.UseCases.Courses.EventHandlers;

public class CourseCreatedEventHandler : INotificationHandler<CourseCreatedEvent>
{
    private readonly ILogger<CourseCreatedEventHandler> _logger;

    public CourseCreatedEventHandler(ILogger<CourseCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CourseCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CourseManagement Domain Event: {DomainEvent} - Course {CourseName} was created.",
            notification.GetType().Name,
            notification.Course.Name);

        return Task.CompletedTask;
    }
}
