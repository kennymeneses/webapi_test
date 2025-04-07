using api.application.Handlers.Abstractions;
using api.application.Handlers.Authorization.Commands.Login;
using api.application.Handlers.Users.Commands.CreateUser;
using api.application.Handlers.Users.Queries.GetUsers;
using Microsoft.Extensions.DependencyInjection;

namespace api.application.Configurations;

public static class HandlerDependencies
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IGetUsersPaginatedHandler, GetUsersPaginatedHandler>();
        services.AddScoped<IUserCreationHandler, UserCreationHandler>();
        services.AddScoped<ILoginHandler, LoginHandler>();
        
        return services;
    }
}