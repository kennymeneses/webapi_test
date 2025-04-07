using api.application.DTOs;
using api.application.Handlers.Users.Commands.CreateUser;

namespace api.application.Handlers.Abstractions;

public interface IUserCreationHandler
{
    Task<UserDto> Handler(CreateUserCommand command, CancellationToken cancellationToken);
}