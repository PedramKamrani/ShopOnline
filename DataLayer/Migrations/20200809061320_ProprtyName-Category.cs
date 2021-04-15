using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ProprtyNameCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoresCategoryId",
                table: "ProprtyNames",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProprtyNames",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProprtyNames");
        }
    }
}
