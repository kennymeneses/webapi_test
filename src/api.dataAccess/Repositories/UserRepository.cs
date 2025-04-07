using api.dataAccess.Configurations;
using api.dataAccess.Entities;
using api.dataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace api.dataAccess.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ApiDbContext _context;
    
    public UserRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        User? user = await _context.Users.AsNoTracking()
                    .Include(user => user.UserPassword)
                    .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
        
        return user;
    }
}