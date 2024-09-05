using IcecreamMAUI.Api.IceCreams.Entities;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.IceCreams;

public static class IceCreamMapper
{
    public static IceCreamOptionDto ToDto(this IceCreamOption option)
    {
        return new IceCreamOptionDto(Flavor: option.Flavour, Topping: option.Topping);
    }

    public static IceCreamOptionDto[] ToDtoArray(this ICollection<IceCreamOption> options)
    {
        return options.Select(x => ToDto(x)).ToArray();
    }

    public static IceCreamDto ToDto(this IceCream iceCream) 
    {
        return new IceCreamDto(iceCream.Id, iceCream.Name, iceCream.Image, iceCream.Price, iceCream.Options.ToDtoArray());
    }
}
