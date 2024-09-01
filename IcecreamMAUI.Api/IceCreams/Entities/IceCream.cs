using System.ComponentModel.DataAnnotations;

namespace IcecreamMAUI.Api.IceCreams.Entities;

public class IceCream
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public required string Name { get; set; }

    [Range(0.1, double.MaxValue)]
    public required double Price { get; set; }

    [Required, MaxLength(180)]
    public required string Image { get; set; }

    public virtual ICollection<IceCreamOption> Options { get; set; } = [];
}
