using api.application.Handlers.Users.Commands.CreateUser;
using api.application.Handlers.Users.Queries.GetUsers;
using api.application.Models.Requests;

namespace api.application.Configurations.Mappings;

public static class UserMappings
{
    public static GetUsersPaginatedQuery ToPaginateQuery(this PaginatedUserRequest request)
    {
        return new GetUsersPaginatedQuery
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            SortBy = request.SortBy,
        };
    }
    
    public static CreateUserCommand ToCommand(this UserCreationRequest request)
    {
        return new CreateUserCommand()
        {
            IdentificationNumber = request.IdentificationNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            Gender = request.Gender,
            Type = request.Type,
            BirthDate = request.BirthDate,
        };
    }
}