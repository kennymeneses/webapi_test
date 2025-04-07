using api.dataAccess.Configurations;
using api.dataAccess.Configurations.Abstractions;
using api.dataAccess.Configurations.ModelOptions;
using Microsoft.EntityFrameworkCore;

namespace api.webapi.Configurations;

public static class ExtensionMethods
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var dbOptions = configuration.GetSection("Database").Get<DatabaseOptions>();
        services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(dbOptions.ConnectionString));
        
        services.AddScoped<IUnitOfWork>(servicesProvider => servicesProvider.GetRequiredService<ApiDbContext>());
        services.AddDataAccessRepositories(configuration);
    }
}