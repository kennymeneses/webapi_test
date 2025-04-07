using api.application.Configurations.Mappings;
using api.application.DTOs;
using api.application.Handlers.Abstractions;
using api.application.Handlers.Authorization.Commands.Login;
using api.application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace api.webapi.Controllers;

public class AuthorizationController(
    ILoginHandler loginHandler
    ): ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(UserLoggedDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        LoginCommand command = request.toCommand();
        
        var result = await loginHandler.Handler(command, cancellationToken);
        
        return Ok(result);
    }
}