using api.dataAccess.Entities.Enums;

namespace api.dataAccess.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public UserType Type { get; set; }
    public int Age { get; set; }
    
}