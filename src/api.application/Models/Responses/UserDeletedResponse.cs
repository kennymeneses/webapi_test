namespace api.application.Models.Responses;

public sealed record UserDeletedResponse
{
    public Guid UserId { get; init; }
}