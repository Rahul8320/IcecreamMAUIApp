using IcecreamMAUI.Api.Data;
using IcecreamMAUI.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IcecreamMAUI.Api.IceCreams.Services;

public class IceCreamService(AppDbContext context) : IIceCreamService
{
    public async Task<IceCreamDto[]> GetAllIceCreamAsync(CancellationToken cancellationToken)
    {
        return await context.IceCreams
            .AsNoTracking()
            .Include(ic => ic.Options)
            .Select(ic => ic.ToDto())
            .ToArrayAsync(cancellationToken);
    }

    public async Task<IceCreamDto?> GetIceCreamByIdAsync(int id, CancellationToken cancellationToken)
    {
        var iceCream = await context.IceCreams
            .AsNoTracking()
            .Include (ic => ic.Options)
            .FirstOrDefaultAsync(ic => ic.Id == id, cancellationToken);

        return iceCream?.ToDto();
    }
}

public interface IIceCreamService
{
    Task<IceCreamDto[]> GetAllIceCreamAsync(CancellationToken cancellationToken);
    Task<IceCreamDto?> GetIceCreamByIdAsync(int id, CancellationToken cancellationToken);
}