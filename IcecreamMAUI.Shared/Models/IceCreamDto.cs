namespace IcecreamMAUI.Shared.Models;

public record IceCreamOptionDto(string Flavor, string Topping); 
public record IceCreamDto(int Id, string Name, string Image, double Price, IceCreamOptionDto[] Options);
