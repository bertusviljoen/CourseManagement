using CourseManagement.Application.Common.Interfaces;

namespace Infrastructure.Services;

public class CurrentUser : IUser
{
    public string? Id => "dev-user"; // Default development user id
}
