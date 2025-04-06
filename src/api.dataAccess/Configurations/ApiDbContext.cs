using api.dataAccess.Configurations.Abstractions;
using api.dataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.dataAccess.Configurations;

public class ApiDbContext: DbContext, IUnitOfWork
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
    {
        
    }
    
    public virtual DbSet<User> Users => Set<User>();
    
    
    public async Task CommitChangesAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }
}