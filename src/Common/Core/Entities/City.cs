namespace Core.Entities;

public class City
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<District> Districts { get; set; } = [];
}
