using api.application.DTOs;
using api.application.Handlers.Users.Queries.GetUser;

namespace api.application.Handlers.Abstractions;

public interface IGetUserHandler
{
    Task<UserDto> Handler(GetUserQuery query, CancellationToken cancellationToken);
}