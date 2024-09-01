using System.ComponentModel.DataAnnotations;

namespace IcecreamMAUI.Api.Orders.Entities;

public class OrderItem
{
    [Key]
    public long Id { get; set; }

    public required long OrderId { get; set; }

    public required int IceCreamId { get; set; }

    [Required, MaxLength(100)]
    public required string IceCreamName { get; set; }

    [Range(0.1, double.MaxValue)]
    public required double IceCreamPrice { get; set; }

    [Range(1, 100)]
    public required int Quantity { get; set; }

    [Required, MaxLength(50)]
    public required string IceCreamFlavour { get; set; }

    [Required, MaxLength(50)]
    public required string IceCreamTopping { get; set; }

    [Range(0.1, double.MaxValue)]
    public required double TotalPrice { get; set; }

    public virtual Order Order { get; set; } = default!;
}
