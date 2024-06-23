using MainService.MessageBroker.Interface;
using MassTransit;

namespace MainService.MessageBroker.Implementation;

public class PublisherService : IPublisherService
{
    private readonly IBus _bus;

    public PublisherService(IBus bus)
    {
        _bus = bus;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        ArgumentNullException.ThrowIfNull(message);
        await _bus.Publish<T>(message, cancellationToken);
    }

    public async Task SendAsync<T>(T message, string queueName, CancellationToken cancellationToken = default) where T : class
    {
        var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{queueName}"));
        await endpoint.Send(message, cancellationToken);
    }
}
