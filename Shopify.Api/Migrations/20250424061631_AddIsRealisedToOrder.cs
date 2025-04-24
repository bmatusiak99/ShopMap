using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopify.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIsRealisedToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRealised",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRealised",
                table: "Orders");
        }
    }
}
