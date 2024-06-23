namespace Core.Entities;

public class UserAddress
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Address { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string? Direction { get; set; }

    public User? User { get; set; }
}