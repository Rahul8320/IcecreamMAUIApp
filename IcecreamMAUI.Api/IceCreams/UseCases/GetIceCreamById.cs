using IcecreamMAUI.Api.IceCreams.Services;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.IceCreams.UseCases;

public static class GetIceCreamById
{
    public static async Task<ServiceResult<IceCreamDto>> Handler(
        int id,
        IIceCreamService iceCreamService,
        CancellationToken cancellationToken)
    {
        var iceCream = await iceCreamService.GetIceCreamByIdAsync(id, cancellationToken);

        if (iceCream == null) 
        {
            return ServiceResult<IceCreamDto>.NotFound($"Ice-Cream with id: {id} not found!");
        }

        return ServiceResult<IceCreamDto>.Success(iceCream);
    }
}