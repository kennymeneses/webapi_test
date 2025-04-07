using api.application.DTOs;
using api.application.Handlers.Users.Queries.GetUsers;

namespace api.application.Handlers.Abstractions;

public interface IGetUsersPaginatedHandler
{
    Task<PaginatedUsersDto> Handler(GetUsersPaginatedQuery query, CancellationToken cancellationToken);
}