using api.dataAccess.Entities.Enums;

namespace api.dataAccess.Entities;

public class User : BaseEntity
{
    public string IdentificationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public UserType Type { get; set; }
    public DateOnly BirthDate { get; set; }
}