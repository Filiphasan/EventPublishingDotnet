namespace Core.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public int Quantity { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; } = [];
}
