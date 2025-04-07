using api.dataAccess.Configurations;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;

namespace api.dataAccess.Repositories;

public class UserPasswordRepository : BaseRepository<UserPassword>, IUserPasswordRepository
{
    private readonly ApiDbContext _context;
    
    public UserPasswordRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}