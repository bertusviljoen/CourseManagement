using Application.UseCases.Courses.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCourseRequest request)
    {
        var command = new CreateCourseCommand
        {
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            MaxStudents = request.MaxStudents,
            IsActive = request.IsActive
        };

        var courseId = await _mediator.Send(command);
        return Ok(courseId);
    }
}
