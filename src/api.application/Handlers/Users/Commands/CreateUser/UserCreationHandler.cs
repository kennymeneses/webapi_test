using api.application.Configurations;
using api.application.DTOs;
using api.application.Handlers.Abstractions;
using api.dataAccess.Configurations.Abstractions;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;

namespace api.application.Handlers.Users.Commands.CreateUser;

public class UserCreationHandler(
    IUserRepository repository,
    IUserPasswordRepository passwordRepository,
    IUnitOfWork unitOfWork) : IUserCreationHandler
{
    public async Task<UserDto> Handler(CreateUserCommand command, CancellationToken cancellationToken)
    {
        User newUser = new()
        {
            Id = Guid.NewGuid(),
            IdentificationNumber = command.IdentificationNumber,
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
        
        UserPassword userPassword = new()
        {
            Id = Guid.NewGuid(),
            UserId = newUser.Id,
            Password = command.Password.ToHash(),
            CreatedTime = DateTimeOffset.UtcNow,
            Deleted = false
        };
        passwordRepository.CreateAsync(userPassword);
         
        await unitOfWork.CommitChangesAsync(cancellationToken);
        
        //dbchallenge
        //test1234techandsolve

        UserDto userDto = new()
        {
            Id = newUser.Id,
            IdentificationNumber = newUser.IdentificationNumber,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email,
            Gender = newUser.Gender,
            Type = newUser.Type,
            BirthDate = newUser.BirthDate
        };
        
        return userDto;
    }
}