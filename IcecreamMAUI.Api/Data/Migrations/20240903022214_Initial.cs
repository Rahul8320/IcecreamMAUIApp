using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IcecreamMAUI.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IceCreams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CustomerAddress = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    TotalPrice = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Salt = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Hash = table.Column<string>(type: "TEXT", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IceCreamOptions",
                columns: table => new
                {
                    IceCreamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Flavour = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Topping = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreamOptions", x => new { x.IceCreamId, x.Flavour, x.Topping });
                    table.ForeignKey(
                        name: "FK_IceCreamOptions_IceCreams_IceCreamId",
                        column: x => x.IceCreamId,
                        principalTable: "IceCreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    IceCreamId = table.Column<int>(type: "INTEGER", nullable: false),
                    IceCreamName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IceCreamPrice = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    IceCreamFlavour = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IceCreamTopping = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TotalPrice = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IceCreams",
                columns: new[] { "Id", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1563805042-7684f0e6dff5", "Chocolate Delight", 415.17000000000002 },
                    { 2, "https://images.unsplash.com/photo-1566843962435-4e5d2c802b4d", "Vanilla Dream", 331.17000000000002 },
                    { 3, "https://images.unsplash.com/photo-1627308595229-7830a5c91f9f", "Strawberry Swirl", 372.67000000000002 },
                    { 4, "https://images.unsplash.com/photo-1589342156669-5c021c8b3fa1", "Minty Fresh", 357.06999999999999 },
                    { 5, "https://images.unsplash.com/photo-1580252737439-c75d799aeb95", "Coffee Buzz", 397.56999999999999 },
                    { 6, "https://images.unsplash.com/photo-1592993470962-7b8fdde9d946", "Caramel Craze", 438.06999999999999 },
                    { 7, "https://images.unsplash.com/photo-1600788649894-40c8b072dc2f", "Peanut Butter Blast", 415.17000000000002 },
                    { 8, "https://images.unsplash.com/photo-1591461440144-bb4bb2b1b07a", "Cookies and Cream", 372.67000000000002 },
                    { 9, "https://images.unsplash.com/photo-1600891965057-3ffadbe7a3c2", "Lemon Zest", 381.76999999999998 },
                    { 10, "https://images.unsplash.com/photo-1589187150010-3ccf387ef6d4", "Raspberry Ripple", 397.56999999999999 }
                });

            migrationBuilder.InsertData(
                table: "IceCreamOptions",
                columns: new[] { "Flavour", "IceCreamId", "Topping" },
                values: new object[,]
                {
                    { "Dark Chocolate", 1, "Choco Chips" },
                    { "Milk Chocolate", 1, "Whipped Cream" },
                    { "Classic Vanilla", 2, "Rainbow Sprinkles" },
                    { "French Vanilla", 2, "Caramel Syrup" },
                    { "Strawberry", 3, "Fresh Strawberries" },
                    { "Strawberry Cheesecake", 3, "Graham Cracker Crumble" },
                    { "Mint", 4, "Chocolate Shavings" },
                    { "Mint Chocolate Chip", 4, "Mint Leaves" },
                    { "Espresso", 5, "Chocolate Espresso Beans" },
                    { "Mocha", 5, "Coffee Syrup" },
                    { "Butterscotch", 6, "Toasted Almonds" },
                    { "Salted Caramel", 6, "Caramel Swirls" },
                    { "Chocolate Peanut Butter", 7, "Peanut Butter Cups" },
                    { "Peanut Butter", 7, "Crushed Peanuts" },
                    { "Cookies and Cream", 8, "Oreo Crumbles" },
                    { "Double Chocolate", 8, "Chocolate Sauce" },
                    { "Lemon", 9, "Lemon Zest" },
                    { "Lemon Meringue", 9, "Meringue Bits" },
                    { "Raspberry", 10, "Fresh Raspberries" },
                    { "Raspberry Cheesecake", 10, "White Chocolate Chips" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IceCreamOptions");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "IceCreams");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
