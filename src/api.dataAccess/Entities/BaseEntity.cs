namespace api.dataAccess.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
    }
    
    public Guid Id { get; init; }

    public DateTimeOffset CreatedTime { get; init; }

    public Guid? CreatedBy { get; init; }

    public DateTimeOffset? LastModifiedTime { get; init; }

    public Guid? ModifiedBy { get; init; }

    public bool Deleted { get; set; }
}