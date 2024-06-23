using Core.Events.Orders;
using MassTransit;

namespace BgWorker.Consumers;

public class CreateOrderPaymentConsumer
    : IConsumer<CreateOrderEvent>
{
    public async Task Consume(ConsumeContext<CreateOrderEvent> context)
    {
        throw new NotImplementedException();
    }
}
