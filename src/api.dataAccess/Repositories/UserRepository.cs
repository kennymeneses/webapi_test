using api.dataAccess.Configurations;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;

namespace api.dataAccess.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ApiDbContext _context;
    
    public UserRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}