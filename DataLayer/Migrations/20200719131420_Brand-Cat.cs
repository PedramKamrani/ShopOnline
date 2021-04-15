using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class BrandCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandCategories_Categories_CategoresCategoryId",
                table: "BrandCategories");

            migrationBuilder.DropIndex(
                name: "IX_BrandCategories_CategoresCategoryId",
                table: "BrandCategories");

            migrationBuilder.DropColumn(
                name: "CategoresCategoryId",
                table: "BrandCategories");

            migrationBuilder.CreateIndex(
                name: "IX_BrandCategories_CategoryId",
                table: "BrandCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandCategories_Categories_CategoryId",
                table: "BrandCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandCategories_Categories_CategoryId",
                table: "BrandCategories");

            migrationBuilder.DropIndex(
                name: "IX_BrandCategories_CategoryId",
                table: "BrandCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoresCategoryId",
                table: "BrandCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BrandCategories_CategoresCategoryId",
                table: "BrandCategories",
                column: "CategoresCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandCategories_Categories_CategoresCategoryId",
                table: "BrandCategories",
                column: "CategoresCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
