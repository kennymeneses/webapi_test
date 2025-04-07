using api.dataAccess.Entities.Enums;

namespace api.application.Handlers.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand
{
    public Guid UserId { get; init; }
    public string? Email { get; set; }
    public UserType? Type { get; set; }
}