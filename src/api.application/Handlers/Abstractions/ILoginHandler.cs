using api.application.DTOs;
using api.application.Handlers.Authorization.Commands.Login;

namespace api.application.Handlers.Abstractions;

public interface ILoginHandler
{
    Task<UserLoggedDto> Handler(LoginCommand command, CancellationToken cancellationToken);
}