using api.application.DTOs;
using api.application.Handlers.Users.Commands.UpdateUser;

namespace api.application.Handlers.Abstractions;

public interface IUpdateUserHandler
{
    Task<UserDto> Handler(UpdateUserCommand command, CancellationToken cancellationToken);
}