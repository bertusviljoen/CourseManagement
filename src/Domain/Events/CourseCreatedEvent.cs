using CourseManagement.Domain.Common;
using CourseManagement.Domain.Entities;

namespace CourseManagement.Domain.Events;

public class CourseCreatedEvent : BaseEvent
{
    public Course Course { get; }

    public CourseCreatedEvent(Course course)
    {
        Course = course;
    }
}
