using api.application.Handlers.Authorization.Commands.Login;
using api.application.Models.Requests;

namespace api.application.Configurations.Mappings;

public static class AuthorizationMappings
{
    public static LoginCommand toCommand(this LoginRequest request)
    {
        return new LoginCommand()
        {
            Email = request.Email,
            Password = request.Password
        };
    }
}