using api.application.Handlers.Users.Commands.DeleteUser;

namespace api.application.Handlers.Abstractions;

public interface IDeleteUserHandler
{
    Task<Guid> Handler(DeleteUserCommand command, CancellationToken cancellationToken);
}