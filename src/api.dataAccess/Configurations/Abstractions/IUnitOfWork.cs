namespace api.dataAccess.Configurations.Abstractions;

public interface IUnitOfWork
{
    Task CommitChangesAsync(CancellationToken cancellationToken);
}