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

        SeedData(builder);
    }

    private static void SeedData(ModelBuilder builder)
    {
        builder.Entity<IceCream>().HasData(
           new IceCream
           {
               Id = 1,
               Name = "Chocolate Delight",
               Price = 415.17,
               Image = "https://images.unsplash.com/photo-1563805042-7684f0e6dff5"
           },
           new IceCream
           {
               Id = 2,
               Name = "Vanilla Dream",
               Price = 331.17,
               Image = "https://images.unsplash.com/photo-1566843962435-4e5d2c802b4d"
           },
           new IceCream
           {
               Id = 3,
               Name = "Strawberry Swirl",
               Price = 372.67,
               Image = "https://images.unsplash.com/photo-1627308595229-7830a5c91f9f"
           },
           new IceCream
           {
               Id = 4,
               Name = "Minty Fresh",
               Price = 357.07,
               Image = "https://images.unsplash.com/photo-1589342156669-5c021c8b3fa1"
           },
           new IceCream
           {
               Id = 5,
               Name = "Coffee Buzz",
               Price = 397.57,
               Image = "https://images.unsplash.com/photo-1580252737439-c75d799aeb95"
           },
           new IceCream
           {
               Id = 6,
               Name = "Caramel Craze",
               Price = 438.07,
               Image = "https://images.unsplash.com/photo-1592993470962-7b8fdde9d946"
           },
           new IceCream
           {
               Id = 7,
               Name = "Peanut Butter Blast",
               Price = 415.17,
               Image = "https://images.unsplash.com/photo-1600788649894-40c8b072dc2f"
           },
           new IceCream
           {
               Id = 8,
               Name = "Cookies and Cream",
               Price = 372.67,
               Image = "https://images.unsplash.com/photo-1591461440144-bb4bb2b1b07a"
           },
           new IceCream
           {
               Id = 9,
               Name = "Lemon Zest",
               Price = 381.77,
               Image = "https://images.unsplash.com/photo-1600891965057-3ffadbe7a3c2"
           },
           new IceCream
           {
               Id = 10,
               Name = "Raspberry Ripple",
               Price = 397.57,
               Image = "https://images.unsplash.com/photo-1589187150010-3ccf387ef6d4"
           }
       );

        builder.Entity<IceCreamOption>().HasData(
            new IceCreamOption
            {
                IceCreamId = 1,
                Flavour = "Dark Chocolate",
                Topping = "Choco Chips"
            },
            new IceCreamOption
            {
                IceCreamId = 1,
                Flavour = "Milk Chocolate",
                Topping = "Whipped Cream"
            },
            new IceCreamOption
            {
                IceCreamId = 2,
                Flavour = "French Vanilla",
                Topping = "Caramel Syrup"
            },
            new IceCreamOption
            {
                IceCreamId = 2,
                Flavour = "Classic Vanilla",
                Topping = "Rainbow Sprinkles"
            },
            new IceCreamOption
            {
                IceCreamId = 3,
                Flavour = "Strawberry",
                Topping = "Fresh Strawberries"
            },
            new IceCreamOption
            {
                IceCreamId = 3,
                Flavour = "Strawberry Cheesecake",
                Topping = "Graham Cracker Crumble"
            },
            new IceCreamOption
            {
                IceCreamId = 4,
                Flavour = "Mint",
                Topping = "Chocolate Shavings"
            },
            new IceCreamOption
            {
                IceCreamId = 4,
                Flavour = "Mint Chocolate Chip",
                Topping = "Mint Leaves"
            },
            new IceCreamOption
            {
                IceCreamId = 5,
                Flavour = "Espresso",
                Topping = "Chocolate Espresso Beans"
            },
            new IceCreamOption
            {
                IceCreamId = 5,
                Flavour = "Mocha",
                Topping = "Coffee Syrup"
            },
            new IceCreamOption
            {
                IceCreamId = 6,
                Flavour = "Salted Caramel",
                Topping = "Caramel Swirls"
            },
            new IceCreamOption
            {
                IceCreamId = 6,
                Flavour = "Butterscotch",
                Topping = "Toasted Almonds"
            },
            new IceCreamOption
            {
                IceCreamId = 7,
                Flavour = "Peanut Butter",
                Topping = "Crushed Peanuts"
            },
            new IceCreamOption
            {
                IceCreamId = 7,
                Flavour = "Chocolate Peanut Butter",
                Topping = "Peanut Butter Cups"
            },
            new IceCreamOption
            {
                IceCreamId = 8,
                Flavour = "Cookies and Cream",
                Topping = "Oreo Crumbles"
            },
            new IceCreamOption
            {
                IceCreamId = 8,
                Flavour = "Double Chocolate",
                Topping = "Chocolate Sauce"
            },
            new IceCreamOption
            {
                IceCreamId = 9,
                Flavour = "Lemon",
                Topping = "Lemon Zest"
            },
            new IceCreamOption
            {
                IceCreamId = 9,
                Flavour = "Lemon Meringue",
                Topping = "Meringue Bits"
            },
            new IceCreamOption
            {
                IceCreamId = 10,
                Flavour = "Raspberry",
                Topping = "Fresh Raspberries"
            },
            new IceCreamOption
            {
                IceCreamId = 10,
                Flavour = "Raspberry Cheesecake",
                Topping = "White Chocolate Chips"
            }
        );
    }
}
