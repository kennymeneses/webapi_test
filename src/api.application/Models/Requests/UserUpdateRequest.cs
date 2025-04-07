using api.dataAccess.Entities.Enums;

namespace api.application.Models.Requests;

public sealed record UserUpdateRequest
{
    public string Email { get; set; }
    public UserType Type { get; set; }
}