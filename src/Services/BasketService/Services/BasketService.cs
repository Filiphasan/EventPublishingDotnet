using Grpc.Core;
using MediatR;

namespace BasketService.Services;

public class BasketService(ISender sender)
    : Basket.BasketBase
{
    // Fill below methods with MediatR implementation
    public override Task<AddBasketResponse> AddBasket(AddBasketRequest request, ServerCallContext context)
    {
        return base.AddBasket(request, context);
    }

    public override Task<GetBasketResponse> GetBasket(GetBasketRequest request, ServerCallContext context)
    {
        return base.GetBasket(request, context);
    }

    public override Task<UpdateBasketResponse> UpdateBasket(UpdateBasketRequest request, ServerCallContext context)
    {
        return base.UpdateBasket(request, context);
    }

    public override Task<DeleteBasketResponse> DeleteBasket(DeleteBasketRequest request, ServerCallContext context)
    {
        return base.DeleteBasket(request, context);
    }
}
