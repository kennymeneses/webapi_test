using api.application.DTOs;
using api.application.Handlers.Abstractions;
using api.dataAccess.Repositories.Abstractions;

namespace api.application.Handlers.Users.Queries.GetUsers;

public class GetUsersPaginatedHandler(
    IUserRepository repository) : IGetUsersPaginatedHandler
{
    public async Task<PaginatedUsersDto> Handler(GetUsersPaginatedQuery query, CancellationToken cancellationToken)
    {
        var users = await repository.ListAsync(cancellationToken);
        
        UserDto[] userDtos = new UserDto[users.Count];

        for (int i = 0; i < users.Count; i++)
        {
            userDtos[i] = new UserDto
            {
                Id = users[i].Id,
                Email = users[i].Email,
                FirstName = users[i].FirstName,
                LastName = users[i].LastName,
                Gender = users[i].Gender,
                Type = users[i].Type,
                BirthDate = users[i].BirthDate
            };
        }

        return new PaginatedUsersDto(
            query.PageNumber ?? query.SafePage,
            query.PageSize ?? query.SafePage,
            users.Count,
            userDtos);
    }
}