namespace api.dataAccess.Entities;

public class UserPassword : BaseEntity
{
    public Guid UserId { get; set; }
    public string Password { get; set; }
    
    public virtual User User { get; set; }
}