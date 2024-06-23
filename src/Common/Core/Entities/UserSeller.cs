namespace Core.Entities;

public class UserSeller
{
    public int UserSellerId { get; set; }
    public int UserId { get; set; }
    public string TaxNumber { get; set; } = null!;
    public string TaxOffice { get; set; } = null!;

    public User User { get; set; } = null!;
}