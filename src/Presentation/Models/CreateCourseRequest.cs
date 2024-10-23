namespace Presentation.Models;

public class CreateCourseRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxStudents { get; set; }
    public bool IsActive { get; set; }
}
