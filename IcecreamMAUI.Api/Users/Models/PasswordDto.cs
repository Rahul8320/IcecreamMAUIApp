namespace IcecreamMAUI.Api.Users.Models;

public class PasswordDto
{
    public required string PlainPassword { get; set; }
    public required string Salt { get; set; }
    public required string HashPassword { get; set; }
}
