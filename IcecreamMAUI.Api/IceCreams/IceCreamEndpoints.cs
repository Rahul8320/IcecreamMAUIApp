using IcecreamMAUI.Api.IceCreams.UseCases;

namespace IcecreamMAUI.Api.IceCreams;

public static class IceCreamEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/ice-creams", GetAllIceCreams.Handler).WithTags("IceCreams");

        app.MapGet("/api/ice-creams/{id:int}", GetIceCreamById.Handler).WithTags("IceCreams");
    }
}