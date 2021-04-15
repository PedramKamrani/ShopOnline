using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class PoprtyCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyCategories",
                columns: table => new
                {
                    PropertyCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyNameId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyCategories", x => x.PropertyCategoryId);
                    table.ForeignKey(
                        name: "FK_PropertyCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyCategories_ProprtyNames_PropertyNameId",
                        column: x => x.PropertyNameId,
                        principalTable: "ProprtyNames",
                        principalColumn: "PropertyNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyCategories_CategoryId",
                table: "PropertyCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyCategories_PropertyNameId",
                table: "PropertyCategories",
                column: "PropertyNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyCategories");
        }
    }
}
