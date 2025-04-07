using api.application.DTOs;
using api.dataAccess.Configurations.Abstractions;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;

namespace api.application.Handlers.Users.Commands.CreateUser;

public class CreateUserHandler(IUserRepository repository, IUnitOfWork unitOfWork)
{
    public async ValueTask<UserDto> Handler(CreateUserCommand command, CancellationToken cancellationToken)
    {
        User newUser = new()
        {
            Id = Guid.NewGuid(),
            IdentificationNumber = command.FirstName,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Gender = command.Gender,
            Type = command.Type,
            CreatedTime = DateTimeOffset.UtcNow,
            BirthDate = command.BirthDate,
            Deleted = false
        };

        repository.CreateAsync(newUser);
        await unitOfWork.CommitChangesAsync(cancellationToken);
        
        //dbchallenge
        //test1234techandsolve

        UserDto userDto = new()
        {
            Id = newUser.Id,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email,
            Gender = newUser.Gender,
            Type = newUser.Type,
        };
        
        return userDto;
    }
}