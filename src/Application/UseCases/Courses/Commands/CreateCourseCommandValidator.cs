namespace Application.UseCases.Courses.Commands;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Description)
            .MaximumLength(2000);
        RuleFor(v => v.StartDate)
            .NotEmpty();
        RuleFor(v => v.EndDate)
            .NotEmpty()
            .GreaterThan(v => v.StartDate);
        RuleFor(v => v.MaxStudents)
            .NotEmpty()
            .GreaterThan(0);
    }
}
