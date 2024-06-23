namespace Core.Constancts;

public static class MessageBrokerConstant
{
    public static class QueueNames
    {
        public const string CreateOrder = "create-order-queue";
        public const string CreateOrderPayment = "create-order-payment-queue";
    }

    public static class ExchangeNames
    {
        public const string CreateOrder = "create-order-exchange";
    }
}
