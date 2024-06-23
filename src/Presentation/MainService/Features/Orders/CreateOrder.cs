using Core.Models.Features;
using MediatR;

namespace MainService.Features.Orders;

public static class CreateOrder
{
    public class Command : IRequest<BaseResponse<Response>>
    {
        public string? DiscountCode { get; set; }
        public List<OrderItem> Items { get; set; } = [];
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Response
    {
        public Ulid OrderId { get; set; }
        public string? Message { get; set; }
    }

    public sealed class Handler : IRequestHandler<Command, BaseResponse<Response>>
    {
        public async Task<BaseResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
