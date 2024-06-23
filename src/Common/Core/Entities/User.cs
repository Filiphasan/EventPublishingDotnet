using Core.Enums.EntityEnums;

namespace Core.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public UserType UserType { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime CreatedDate { get; set; }

    public UserSeller? UserSeller { get; set; }
    public ICollection<UserAddress> UserAddresses { get; set; } = [];
}