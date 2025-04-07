using api.application.Configurations.Mappings;
using api.application.DTOs;
using api.application.Handlers.Abstractions;
using api.application.Handlers.Users.Commands.CreateUser;
using api.application.Handlers.Users.Commands.DeleteUser;
using api.application.Handlers.Users.Commands.UpdateUser;
using api.application.Handlers.Users.Queries.GetUser;
using api.application.Handlers.Users.Queries.GetUsers;
using api.application.Models.Requests;
using api.application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.webapi.Controllers;

public class UsersController(
    IUserCreationHandler creationHandler,
    IGetUsersPaginatedHandler getUsersHandler,
    IGetUserHandler getUserHandler,
    IUpdateUserHandler updateUserHandler,
    IDeleteUserHandler deleteUserHandler): BaseController
{
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedUsersDto), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<PaginatedUsersDto>> GetAllUsers([FromQuery] PaginatedUserRequest request, CancellationToken cancellationToken)
    {
        GetUsersPaginatedQuery query = request.ToPaginateQuery();
        PaginatedUsersDto users = await getUsersHandler.Handler(query, cancellationToken);
        
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        GetUserQuery query = new GetUserQuery(id);
        UserDto result = await getUserHandler.Handler(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser(UserCreationRequest request, CancellationToken cancellationToken)
    {
        CreateUserCommand command = request.ToCommand();
        
        var result = await creationHandler.Handler(command, cancellationToken);
        
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UserUpdateRequest request, CancellationToken cancellationToken)
    {
        UpdateUserCommand command = new()
        {
            UserId = id,
            Email = request.Email,
            Type = request.Type
        };
        
        UserDto result = await updateUserHandler.Handler(command, cancellationToken);
        
        return Ok(result);
    }
    
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(UserDeletedResponse), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> RemoveItem([FromRoute] Guid id ,CancellationToken cancellationToken)
    {
        DeleteUserCommand command = new(id);
        
        UserDeletedResponse result = await deleteUserHandler.Handler(command, cancellationToken);
        
        return Ok(result);
    }
}