using api.dataAccess.Configurations;
using api.dataAccess.Configurations.Abstractions;

namespace api.webapi.Configurations;

public static class ExtensionMethods
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork>(servicesProvider => servicesProvider.GetRequiredService<ApiDbContext>());
        services.AddDataAccessRepositories(configuration);
    }
}