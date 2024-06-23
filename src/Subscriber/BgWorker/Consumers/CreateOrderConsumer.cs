using Core.Enums.EntityEnums;
using Core.Events.Orders;
using Data.Contexts;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace BgWorker.Consumers;

public class CreateOrderConsumer(
    MainDbContext dbContext,
    ILogger<CreateOrderConsumer> logger)
    : IConsumer<CreateOrderEvent>
{
    public async Task Consume(ConsumeContext<CreateOrderEvent> context)
    {
        var model = context.Message;
        await dbContext.Orders
            .Where(x => x.Id == model.OrderId)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.OrderStatus, OrderStatusType.Pending));
        logger.LogInformation("Order Created: {OrderId}", model.OrderId);
    }
}
