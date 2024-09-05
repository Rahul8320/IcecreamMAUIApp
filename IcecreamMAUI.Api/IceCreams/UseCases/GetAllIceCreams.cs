using IcecreamMAUI.Api.IceCreams.Services;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.IceCreams.UseCases;

public static class GetAllIceCreams
{   
    public static async Task<ServiceResult<IceCreamDto[]>> Handler(
        IIceCreamService iceCreamService, 
        CancellationToken cancellationToken)
    {
        var iceCreams = await iceCreamService.GetAllIceCreamAsync(cancellationToken);

        return ServiceResult<IceCreamDto[]>.Success(iceCreams);
    }
}
