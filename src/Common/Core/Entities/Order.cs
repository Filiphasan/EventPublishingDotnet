using Core.Enums.EntityEnums;

namespace Core.Entities;

public class Order
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatusType OrderStatus { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; } = [];
}
