using api.dataAccess.Entities.Enums;

namespace api.application.Handlers.Users.Commands.CreateUser;

public class CreateUserCommand
{
    public string IdentificationNumber { get; set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public Gender Gender { get; init; }
    public UserType Type { get; init; }
    public DateOnly BirthDate { get; set; }
}