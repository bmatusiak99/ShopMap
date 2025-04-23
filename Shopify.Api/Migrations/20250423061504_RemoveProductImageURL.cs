using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopify.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageURL",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImageURL",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductImageURL",
                value: "/Images/Beauty/Beauty1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductImageURL",
                value: "/Images/Beauty/Beauty2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductImageURL",
                value: "/Images/Beauty/Beauty3.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductImageURL",
                value: "/Images/Beauty/Beauty4.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductImageURL",
                value: "/Images/Beauty/Beauty5.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductImageURL",
                value: "/Images/Electronic/Electronics1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductImageURL",
                value: "/Images/Electronic/Electronics2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductImageURL",
                value: "/Images/Electronic/Electronics3.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductImageURL",
                value: "/Images/Electronic/Electronic4.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductImageURL",
                value: "/Images/Electronic/Electronic5.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductImageURL",
                value: "/Images/Electronic/technology6.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductImageURL",
                value: "/Images/Furniture/Furniture1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductImageURL",
                value: "/Images/Furniture/Furniture2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductImageURL",
                value: "/Images/Furniture/Furniture3.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductImageURL",
                value: "/Images/Furniture/Furniture4.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductImageURL",
                value: "/Images/Furniture/Furniture6.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ProductImageURL",
                value: "/Images/Furniture/Furniture7.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ProductImageURL",
                value: "/Images/Shoes/Shoes1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ProductImageURL",
                value: "/Images/Shoes/Shoes2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ProductImageURL",
                value: "/Images/Shoes/Shoes3.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "ProductImageURL",
                value: "/Images/Shoes/Shoes4.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "ProductImageURL",
                value: "/Images/Shoes/Shoes5.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "ProductImageURL",
                value: "/Images/Shoes/Shoes6.png");
        }
    }
}
