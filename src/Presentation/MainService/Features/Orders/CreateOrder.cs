using Core.Entities;
using Core.Enums.EntityEnums;
using Core.Events.Orders;
using Core.Models.Features;
using Data.Contexts;
using MainService.MessageBroker.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MainService.Features.Orders;

public static class CreateOrder
{
    public class Command : IRequest<BaseResponse<Response>>
    {
        public List<OrderItem> Items { get; set; } = [];
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Response
    {
        public long OrderId { get; set; }
        public string? Message { get; set; }
    }

    public sealed class Handler(MainDbContext context, IPublisherService publisherService)
        : IRequestHandler<Command, BaseResponse<Response>>
    {
        public async Task<BaseResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var response = new Response();

            var productIdHashSet = request.Items.Select(x => x.ProductId).ToHashSet();
            var products = await context.Products
                .Where(x => productIdHashSet.Contains(x.Id))
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var order = new Order
            {
                UserId = 1,
                OrderStatus = OrderStatusType.Created,
                TotalPrice = products.Sum(x => x.Price),
            };
            await context.Orders.AddAsync(order, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            var orderProductList = request.Items
                .Select(x => new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    TotalPrice = x.Quantity * products.First(y => y.Id == x.ProductId).Price,
                })
                .ToList();

            await context.OrderProducts.AddRangeAsync(orderProductList, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            await publisherService.PublishAsync(new CreateOrderEvent
            {
                OrderId = order.Id
            }, cancellationToken);

            response.OrderId = order.Id;
            response.Message = "Order created successfully.";
            return BaseResponse<Response>.Success(response);
        }
    }
}
