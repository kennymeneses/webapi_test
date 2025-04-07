using api.application.Configurations.Mappings;
using api.application.DTOs;
using api.application.Handlers.Abstractions;
using api.application.Handlers.Users.Commands.CreateUser;
using api.application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.webapi.Controllers;

public class UsersController(
    IUserCreationHandler creationHandler,
    IGetUsersPaginatedHandler usersHandler
    ): BaseController
{
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedUsersDto), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<PaginatedUsersDto>> GetAllUsers([FromQuery] PaginatedUserRequest request, CancellationToken cancellationToken)
    {
        
        return Ok();
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateItem(UserCreationRequest request, CancellationToken cancellationToken)
    {
        CreateUserCommand command = request.ToCommand();
        
        var result = await creationHandler.Handler(command, cancellationToken);
        
        return Ok(result);
    }
}