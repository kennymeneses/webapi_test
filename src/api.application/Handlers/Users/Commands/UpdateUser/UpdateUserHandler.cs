using api.application.DTOs;
using api.application.Handlers.Abstractions;
using api.dataAccess.Configurations.Abstractions;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;

namespace api.application.Handlers.Users.Commands.UpdateUser;

public sealed class UpdateUserHandler(
    IUserRepository repository,
    IUnitOfWork unitOfWork) : IUpdateUserHandler
{
    public async Task<UserDto> Handler(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await repository.FirstOrDefaultAsync<User>(user => user.Id == command.UserId, cancellationToken);
        
        if (user is null) throw new KeyNotFoundException($"User with id {command.UserId} not found");
        
        user.Type = command.Type ?? user.Type;
        user.Email = command.Email ?? user.Email;
        
        repository.Update(user);
        
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return new UserDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Type = user.Type,
            Gender = user.Gender,
            BirthDate = user.BirthDate,
        };
    }
}