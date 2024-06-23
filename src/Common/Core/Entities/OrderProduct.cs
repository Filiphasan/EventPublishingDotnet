namespace Core.Entities;

public class OrderProduct
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public Order? Order { get; set; }
    public Product? Product { get; set; }
}
