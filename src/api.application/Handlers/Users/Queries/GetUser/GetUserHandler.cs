using api.application.DTOs;
using api.application.Handlers.Abstractions;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;

namespace api.application.Handlers.Users.Queries.GetUser;

public class GetUserHandler(IUserRepository repository) : IGetUserHandler
{
    public async Task<UserDto> Handler(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = await repository.FirstOrDefaultAsync<User>(user => user.Id == query.userId, cancellationToken);
        
        if (user is null) throw new KeyNotFoundException($"User with id {query.userId} not found");
        
        return new UserDto()
        {
            Id = user.Id,
            IdentificationNumber = user.IdentificationNumber,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = user.BirthDate,
            Gender = user.Gender,
            Type = user.Type,
        };
    }
}