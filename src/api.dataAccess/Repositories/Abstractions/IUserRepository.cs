using api.dataAccess.Entities;

namespace api.dataAccess.Repositories.Abstractions;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
}