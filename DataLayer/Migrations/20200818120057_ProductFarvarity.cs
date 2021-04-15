using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ProductFarvarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProductFovorites_Products_ProductsProductId",
                table: "UserProductFovorites");

            migrationBuilder.DropIndex(
                name: "IX_UserProductFovorites_ProductsProductId",
                table: "UserProductFovorites");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "UserProductFovorites");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductFovorites_ProductId",
                table: "UserProductFovorites",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductFovorites_Products_ProductId",
                table: "UserProductFovorites",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProductFovorites_Products_ProductId",
                table: "UserProductFovorites");

            migrationBuilder.DropIndex(
                name: "IX_UserProductFovorites_ProductId",
                table: "UserProductFovorites");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "UserProductFovorites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProductFovorites_ProductsProductId",
                table: "UserProductFovorites",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductFovorites_Products_ProductsProductId",
                table: "UserProductFovorites",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
