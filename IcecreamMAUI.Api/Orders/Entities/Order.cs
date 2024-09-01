using System.ComponentModel.DataAnnotations;

namespace IcecreamMAUI.Api.Orders.Entities;

public class Order
{
    [Key]
    public long Id { get; set; }

    public DateTime OrderAt { get; set; } = DateTime.Now;

    public required Guid CustomerId { get; set; }

    [Required, MaxLength(30)]
    public required string CustomerName { get; set; }

    [Required, MaxLength(100)]
    public required string CustomerEmail { get; set; }

    [Required, MaxLength(150)]
    public required string CustomerAddress { get; set; }

    [Range(0.1, double.MaxValue)]
    public double TotalPrice { get; set; }

    public virtual IEnumerable<OrderItem> Items { get; set; } = [];
}
