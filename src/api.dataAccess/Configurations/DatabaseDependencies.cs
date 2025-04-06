using api.dataAccess.Repositories;
using api.dataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.dataAccess.Configurations;

public static class DatabaseDependencies
{
    public static IServiceCollection AddDataAccessRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}