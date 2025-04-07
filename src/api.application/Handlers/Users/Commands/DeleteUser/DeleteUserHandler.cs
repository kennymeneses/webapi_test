using api.application.Handlers.Abstractions;
using api.application.Models.Responses;
using api.dataAccess.Configurations.Abstractions;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;

namespace api.application.Handlers.Users.Commands.DeleteUser;

public class DeleteUserHandler(
    IUserRepository repository,
    IUserPasswordRepository userPasswordRepository,
    IUnitOfWork unitOfWork) : IDeleteUserHandler
{
    public async Task<UserDeletedResponse> Handler(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        User? user = await repository.FirstOrDefaultAsync<User>(user => user.Id == command.UserId, cancellationToken);
        
        if (user is null) throw new KeyNotFoundException($"User with id {command.UserId} not found");
        
        UserPassword? userPassword = await userPasswordRepository.FirstOrDefaultAsync<UserPassword>(userPassword => userPassword.UserId == command.UserId, cancellationToken);
        
        user.Deleted = true;
        repository.Update(user);
        
        userPassword!.Deleted = true;
        userPasswordRepository.Update(userPassword);
        
        await unitOfWork.CommitChangesAsync(cancellationToken);
        
        return new UserDeletedResponse()
        {
            UserId = user.Id
        };
    }
}