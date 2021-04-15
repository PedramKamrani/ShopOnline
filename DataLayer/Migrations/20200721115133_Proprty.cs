using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Proprty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProprtyGroups",
                columns: table => new
                {
                    PropertyGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    WikiText = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprtyGroups", x => x.PropertyGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ProprtyNames",
                columns: table => new
                {
                    PropertyNameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    UseSearch = table.Column<bool>(nullable: false),
                    PropertyGroupId = table.Column<int>(nullable: false),
                    WikiText = table.Column<string>(maxLength: 1000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ProprtyGroupPropertyGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprtyNames", x => x.PropertyNameId);
                    table.ForeignKey(
                        name: "FK_ProprtyNames_ProprtyGroups_ProprtyGroupPropertyGroupId",
                        column: x => x.ProprtyGroupPropertyGroupId,
                        principalTable: "ProprtyGroups",
                        principalColumn: "PropertyGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyValues",
                columns: table => new
                {
                    PropertyValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 200, nullable: false),
                    PropertyNameId = table.Column<int>(nullable: false),
                    WikiText = table.Column<string>(maxLength: 1000, nullable: true),
                    ProprtyNamePropertyNameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValues", x => x.PropertyValueId);
                    table.ForeignKey(
                        name: "FK_PropertyValues_ProprtyNames_ProprtyNamePropertyNameId",
                        column: x => x.ProprtyNamePropertyNameId,
                        principalTable: "ProprtyNames",
                        principalColumn: "PropertyNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    ProductPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    PropertyValueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.ProductPropertyId);
                    table.ForeignKey(
                        name: "FK_ProductProperties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProperties_PropertyValues_PropertyValueId",
                        column: x => x.PropertyValueId,
                        principalTable: "PropertyValues",
                        principalColumn: "PropertyValueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_PropertyValueId",
                table: "ProductProperties",
                column: "PropertyValueId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyValues_ProprtyNamePropertyNameId",
                table: "PropertyValues",
                column: "ProprtyNamePropertyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProprtyNames_ProprtyGroupPropertyGroupId",
                table: "ProprtyNames",
                column: "ProprtyGroupPropertyGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropTable(
                name: "PropertyValues");

            migrationBuilder.DropTable(
                name: "ProprtyNames");

            migrationBuilder.DropTable(
                name: "ProprtyGroups");
        }
    }
}
