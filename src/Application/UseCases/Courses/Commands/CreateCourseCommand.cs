using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Courses.Commands;

public record CreateCourseCommand : IRequest<int>
{
    [Required]
    public string Name { get; init; } = string.Empty;

    [Required]
    public string Description { get; init; } = string.Empty;

    [Required]
    public DateTime StartDate { get; init; }

    [Required]
    public DateTime EndDate { get; init; }

    [Range(1, int.MaxValue, ErrorMessage = "MaxStudents must be greater than 0")]
    public int MaxStudents { get; init; }

    public bool IsActive { get; init; }

    public CreateCourseCommand()
    {
        if (EndDate <= StartDate)
        {
            throw new ArgumentException("EndDate must be after StartDate");
        }
    }
}
