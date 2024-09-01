using System.ComponentModel.DataAnnotations;

namespace IcecreamMAUI.Api.Users.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(30)]
    public required string Name { get; set; }

    [Required, MaxLength(100)]
    public required string Email { get; set; }

    [Required, MaxLength(150)]
    public required string Address { get; set; }

    [Required, MaxLength(20)]
    public required string Salt { get; set; }

    [Required, MaxLength(180)]
    public required string Hash { get; set; }
}
