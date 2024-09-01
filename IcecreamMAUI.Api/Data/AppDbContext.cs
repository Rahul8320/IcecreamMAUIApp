using IcecreamMAUI.Api.IceCreams.Entities;
using IcecreamMAUI.Api.Orders.Entities;
using IcecreamMAUI.Api.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace IcecreamMAUI.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<IceCream> IceCreams { get; set; }
    public DbSet<IceCreamOption> IceCreamOptions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IceCreamOption>().HasKey(io => new { io.IceCreamId, io.Flavour, io.Topping });
    }
}
