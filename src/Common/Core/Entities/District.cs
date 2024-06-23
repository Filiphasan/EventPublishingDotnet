namespace Core.Entities;

public class District
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CityId { get; set; }

    public City? City { get; set; }
}
