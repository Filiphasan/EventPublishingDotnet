using Carter;

namespace MainService.Endpoints;

public abstract class BaseEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException();
    }


}
