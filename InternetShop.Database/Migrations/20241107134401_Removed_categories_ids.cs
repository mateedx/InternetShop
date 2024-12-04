using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetShop.Database.Migrations
{
    /// <inheritdoc />
    public partial class Removed_categories_ids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_ProductVariations_VariationId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderProducts");

            migrationBuilder.RenameColumn(
                name: "VariationId",
                table: "OrderProducts",
                newName: "ProductVariationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_VariationId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductVariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_ProductVariations_ProductVariationId",
                table: "OrderProducts",
                column: "ProductVariationId",
                principalTable: "ProductVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_ProductVariations_ProductVariationId",
                table: "OrderProducts");

            migrationBuilder.RenameColumn(
                name: "ProductVariationId",
                table: "OrderProducts",
                newName: "VariationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductVariationId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_VariationId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_ProductVariations_VariationId",
                table: "OrderProducts",
                column: "VariationId",
                principalTable: "ProductVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
