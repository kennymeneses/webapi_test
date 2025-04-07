using api.application.Handlers.Users.Commands.DeleteUser;
using api.application.Models.Responses;

namespace api.application.Handlers.Abstractions;

public interface IDeleteUserHandler
{
    Task<UserDeletedResponse> Handler(DeleteUserCommand command, CancellationToken cancellationToken);
}