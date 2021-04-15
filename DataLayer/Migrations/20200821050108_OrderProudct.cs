using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class OrderProudct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderProuducts",
                columns: table => new
                {
                    OrderProuductsid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    creatDate = table.Column<DateTime>(nullable: false),
                    IsFainally = table.Column<bool>(nullable: false),
                    Sum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProuducts", x => x.OrderProuductsid);
                    table.ForeignKey(
                        name: "FK_OrderProuducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailesOrders",
                columns: table => new
                {
                    DetailesOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Ordeid = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    OrderProuductsid = table.Column<int>(nullable: true),
                    ProductsProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailesOrders", x => x.DetailesOrderId);
                    table.ForeignKey(
                        name: "FK_DetailesOrders_OrderProuducts_OrderProuductsid",
                        column: x => x.OrderProuductsid,
                        principalTable: "OrderProuducts",
                        principalColumn: "OrderProuductsid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailesOrders_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailesOrders_OrderProuductsid",
                table: "DetailesOrders",
                column: "OrderProuductsid");

            migrationBuilder.CreateIndex(
                name: "IX_DetailesOrders_ProductsProductId",
                table: "DetailesOrders",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProuducts_UserId",
                table: "OrderProuducts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailesOrders");

            migrationBuilder.DropTable(
                name: "OrderProuducts");
        }
    }
}
