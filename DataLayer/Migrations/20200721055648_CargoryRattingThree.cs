using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CargoryRattingThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRaview_Products_ProductId",
                table: "ProductRaview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRaview",
                table: "ProductRaview");

            migrationBuilder.RenameTable(
                name: "ProductRaview",
                newName: "ProductRaviews");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRaview_ProductId",
                table: "ProductRaviews",
                newName: "IX_ProductRaviews_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRaviews",
                table: "ProductRaviews",
                column: "ProductReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRaviews_Products_ProductId",
                table: "ProductRaviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRaviews_Products_ProductId",
                table: "ProductRaviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRaviews",
                table: "ProductRaviews");

            migrationBuilder.RenameTable(
                name: "ProductRaviews",
                newName: "ProductRaview");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRaviews_ProductId",
                table: "ProductRaview",
                newName: "IX_ProductRaview_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRaview",
                table: "ProductRaview",
                column: "ProductReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRaview_Products_ProductId",
                table: "ProductRaview",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
