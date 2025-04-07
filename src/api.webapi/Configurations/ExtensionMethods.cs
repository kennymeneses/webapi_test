using System.Text;
using api.application.Configurations;
using api.application.Models;
using api.dataAccess.Configurations;
using api.dataAccess.Configurations.Abstractions;
using api.webapi.Configurations.ModelOptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

    public static void AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationOptions = new AuthenticationOptions();
        IConfigurationSection authOptions = configuration.GetSection("Authentication");
        authOptions.Bind(authenticationOptions);
        services.Configure<AuthenticationOptions>(authOptions);
        
        services.AddAuthentication(authenticationOptions =>
        {
            authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwtBearerOptions =>
        {
            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = "demo.com",
                ValidAudience = "demo.com",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationOptions.IssueSigningKey)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });
    }

    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHandlers();
    }
}