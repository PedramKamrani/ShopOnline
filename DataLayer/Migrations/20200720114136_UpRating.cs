using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class UpRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRaview_Products_ProductsProductId",
                table: "ProductRaview");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoresCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoresCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductRaview_ProductsProductId",
                table: "ProductRaview");

            migrationBuilder.DropColumn(
                name: "CategoresCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "ProductRaview");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRaview_ProductId",
                table: "ProductRaview",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRaview_Products_ProductId",
                table: "ProductRaview",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRaview_Products_ProductId",
                table: "ProductRaview");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductRaview_ProductId",
                table: "ProductRaview");

            migrationBuilder.AddColumn<int>(
                name: "CategoresCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "ProductRaview",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoresCategoryId",
                table: "Products",
                column: "CategoresCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRaview_ProductsProductId",
                table: "ProductRaview",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRaview_Products_ProductsProductId",
                table: "ProductRaview",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoresCategoryId",
                table: "Products",
                column: "CategoresCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
