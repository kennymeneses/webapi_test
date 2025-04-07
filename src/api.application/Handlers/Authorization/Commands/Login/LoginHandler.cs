using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.application.DTOs;
using api.application.Handlers.Abstractions;
using api.application.Models;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace api.application.Handlers.Authorization.Commands.Login;

public class LoginHandler(
    IUserRepository repository,
    IOptions<AuthenticationOptions> authOptions,
    IUserPasswordRepository passwordRepository) : ILoginHandler
{
    public async Task<UserLoggedDto> Handler(LoginCommand command, CancellationToken cancellationToken)
    {
        bool exists = await repository.ExistsAsync(user => user.Email == command.Email, cancellationToken);

        if (!exists)
        {
            throw new KeyNotFoundException($"User with email {command.Email} does not exist");
        }
        
        User user = await repository.FirstOrDefaultAsync<User>(user => user.Email == command.Email, cancellationToken);

        if (user.Email != command.Email || user.UserPassword.Password != command.Password)
        {
            throw new UnauthorizedAccessException($"User with email {command.Email} does not exist");
        }

        return new UserLoggedDto
        {
            Token = BuildJwtToken(user)
        };
    }

    private string BuildJwtToken(User user)
    {
        var claimsList = new List<Claim>()
        {
            new (ClaimType.ClaimDniType, user.IdentificationNumber),
            new (ClaimType.ClaimIdType, user.Id.ToString()),
        };
        
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Value.IssueSigningKey));
        
        var signCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        DateTime expiration = DateTime.Now.AddHours(8);
        
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: "demo.com",
            audience: "demo.com",
            claims: claimsList,
            expires: expiration,
            signingCredentials: signCredential
        );
        
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}