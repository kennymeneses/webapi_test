using api.application.Models.Responses;

namespace api.application.DTOs;

public sealed record PaginatedUsersDto : PaginatedResponse<UserDto>
{
    public PaginatedUsersDto(int pageNumber, int pageSize, long totalItems, IReadOnlyList<UserDto> results) 
        : base(pageNumber, pageSize, totalItems, results)
    {
    }
}