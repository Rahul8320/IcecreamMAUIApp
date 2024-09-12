using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IcecreamMAUI.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updateicecreamsimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://images.unsplash.com/photo-1607920591413-4ec007e70023?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://plus.unsplash.com/premium_photo-1690440686714-c06a56a1511c?q=80&w=1964&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://images.unsplash.com/photo-1532678465554-94846274c297?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://plus.unsplash.com/premium_photo-1678198786424-c2cc6593f59c?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://images.unsplash.com/photo-1576506295286-5cda18df43e7?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://images.unsplash.com/photo-1570197788417-0e82375c9371?q=80&w=1912&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://images.unsplash.com/photo-1560008581-09826d1de69e?q=80&w=1944&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://images.unsplash.com/photo-1580915411954-282cb1b0d780?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "https://images.unsplash.com/photo-1534706936160-d5ee67737249?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 10,
                column: "Image",
                value: "https://plus.unsplash.com/premium_photo-1670574528579-c7eec79d7b7c?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://images.unsplash.com/photo-1563805042-7684f0e6dff5");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://images.unsplash.com/photo-1566843962435-4e5d2c802b4d");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://images.unsplash.com/photo-1627308595229-7830a5c91f9f");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://images.unsplash.com/photo-1589342156669-5c021c8b3fa1");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://images.unsplash.com/photo-1580252737439-c75d799aeb95");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://images.unsplash.com/photo-1592993470962-7b8fdde9d946");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://images.unsplash.com/photo-1600788649894-40c8b072dc2f");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://images.unsplash.com/photo-1591461440144-bb4bb2b1b07a");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "https://images.unsplash.com/photo-1600891965057-3ffadbe7a3c2");

            migrationBuilder.UpdateData(
                table: "IceCreams",
                keyColumn: "Id",
                keyValue: 10,
                column: "Image",
                value: "https://images.unsplash.com/photo-1589187150010-3ccf387ef6d4");
        }
    }
}
