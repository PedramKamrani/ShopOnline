using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class propMameC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProprtyNames_Categories_CategoryId",
                table: "ProprtyNames");

            migrationBuilder.DropIndex(
                name: "IX_ProprtyNames_CategoryId",
                table: "ProprtyNames");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProprtyNames");

            migrationBuilder.AddColumn<int>(
                name: "CategoresCategoryId",
                table: "ProprtyNames",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProprtyNames_CategoresCategoryId",
                table: "ProprtyNames",
                column: "CategoresCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProprtyNames_Categories_CategoresCategoryId",
                table: "ProprtyNames",
                column: "CategoresCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProprtyNames_Categories_CategoresCategoryId",
                table: "ProprtyNames");

            migrationBuilder.DropIndex(
                name: "IX_ProprtyNames_CategoresCategoryId",
                table: "ProprtyNames");

            migrationBuilder.DropColumn(
                name: "CategoresCategoryId",
                table: "ProprtyNames");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProprtyNames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProprtyNames_CategoryId",
                table: "ProprtyNames",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProprtyNames_Categories_CategoryId",
                table: "ProprtyNames",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
