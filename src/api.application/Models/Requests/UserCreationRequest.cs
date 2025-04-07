using api.dataAccess.Entities.Enums;

namespace api.application.Models.Requests;

public class UserCreationRequest
{
    public required string IdentificationNumber { get; set; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required Gender Gender { get; init; }
    public required UserType Type { get; init; }
    public required DateOnly BirthDate { get; set; }
}