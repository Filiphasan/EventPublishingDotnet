namespace Core.Constancts;

public static class MessageBrokerConstant
{
    public static class QueueNames
    {
        private const string HandleOrder = "handle-order";
    }

    public static class ExchangeNames
    {
        public const string HandleOrder = "handle-order-exchange";
    }
}