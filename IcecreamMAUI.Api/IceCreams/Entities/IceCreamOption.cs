using System.ComponentModel.DataAnnotations;

namespace IcecreamMAUI.Api.IceCreams.Entities;

public class IceCreamOption
{
    public required int IceCreamId { get; set; }

    [Required, MaxLength(50)]
    public required string Flavour { get; set; }

    [Required, MaxLength(50)]
    public required string Topping { get; set; }

    public virtual IceCream IceCream { get; set; } = default!;
}
