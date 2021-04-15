using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class OrderProudctt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailesOrders_OrderProuducts_OrderProuductsid",
                table: "DetailesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailesOrders_Products_ProductsProductId",
                table: "DetailesOrders");

            migrationBuilder.DropIndex(
                name: "IX_DetailesOrders_OrderProuductsid",
                table: "DetailesOrders");

            migrationBuilder.DropIndex(
                name: "IX_DetailesOrders_ProductsProductId",
                table: "DetailesOrders");

            migrationBuilder.DropColumn(
                name: "OrderProuductsid",
                table: "DetailesOrders");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "DetailesOrders");

            migrationBuilder.CreateIndex(
                name: "IX_DetailesOrders_Ordeid",
                table: "DetailesOrders",
                column: "Ordeid");

            migrationBuilder.CreateIndex(
                name: "IX_DetailesOrders_ProductId",
                table: "DetailesOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailesOrders_OrderProuducts_Ordeid",
                table: "DetailesOrders",
                column: "Ordeid",
                principalTable: "OrderProuducts",
                principalColumn: "OrderProuductsid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailesOrders_Products_ProductId",
                table: "DetailesOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailesOrders_OrderProuducts_Ordeid",
                table: "DetailesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailesOrders_Products_ProductId",
                table: "DetailesOrders");

            migrationBuilder.DropIndex(
                name: "IX_DetailesOrders_Ordeid",
                table: "DetailesOrders");

            migrationBuilder.DropIndex(
                name: "IX_DetailesOrders_ProductId",
                table: "DetailesOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderProuductsid",
                table: "DetailesOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "DetailesOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailesOrders_OrderProuductsid",
                table: "DetailesOrders",
                column: "OrderProuductsid");

            migrationBuilder.CreateIndex(
                name: "IX_DetailesOrders_ProductsProductId",
                table: "DetailesOrders",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailesOrders_OrderProuducts_OrderProuductsid",
                table: "DetailesOrders",
                column: "OrderProuductsid",
                principalTable: "OrderProuducts",
                principalColumn: "OrderProuductsid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailesOrders_Products_ProductsProductId",
                table: "DetailesOrders",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
