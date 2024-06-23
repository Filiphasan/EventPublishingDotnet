namespace MainService.MessageBroker.Interface;

public interface IPublisherService
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken = default)  where T : class;
    Task SendAsync<T>(T message, string queueName, CancellationToken cancellationToken = default)  where T : class;
}
