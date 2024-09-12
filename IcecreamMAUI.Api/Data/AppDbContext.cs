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
               Image = "https://images.unsplash.com/photo-1607920591413-4ec007e70023?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 2,
               Name = "Vanilla Dream",
               Price = 331.17,
               Image = "https://plus.unsplash.com/premium_photo-1690440686714-c06a56a1511c?q=80&w=1964&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 3,
               Name = "Strawberry Swirl",
               Price = 372.67,
               Image = "https://images.unsplash.com/photo-1532678465554-94846274c297?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 4,
               Name = "Minty Fresh",
               Price = 357.07,
               Image = "https://plus.unsplash.com/premium_photo-1678198786424-c2cc6593f59c?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 5,
               Name = "Coffee Buzz",
               Price = 397.57,
               Image = "https://images.unsplash.com/photo-1576506295286-5cda18df43e7?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 6,
               Name = "Caramel Craze",
               Price = 438.07,
               Image = "https://images.unsplash.com/photo-1570197788417-0e82375c9371?q=80&w=1912&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 7,
               Name = "Peanut Butter Blast",
               Price = 415.17,
               Image = "https://images.unsplash.com/photo-1560008581-09826d1de69e?q=80&w=1944&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 8,
               Name = "Cookies and Cream",
               Price = 372.67,
               Image = "https://images.unsplash.com/photo-1580915411954-282cb1b0d780?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 9,
               Name = "Lemon Zest",
               Price = 381.77,
               Image = "https://images.unsplash.com/photo-1534706936160-d5ee67737249?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
           },
           new IceCream
           {
               Id = 10,
               Name = "Raspberry Ripple",
               Price = 397.57,
               Image = "https://plus.unsplash.com/premium_photo-1670574528579-c7eec79d7b7c?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
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
