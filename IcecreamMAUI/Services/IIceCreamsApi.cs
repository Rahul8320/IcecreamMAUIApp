using IcecreamMAUI.Shared.Models;
using Refit;

namespace IcecreamMAUI.Services;

public interface IIceCreamsApi
{
    [Get("/api/ice-creams")]
    Task<ServiceResult<IceCreamDto[]>> GetAllIceCreamAsync(CancellationToken cancellationToken = default);

    [Get("/api/ice-creams/{id}")]
    Task<ServiceResult<IceCreamDto>> GetIceCreamDetails(int id, CancellationToken cancellationToken = default);
}