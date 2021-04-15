using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class MainMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainMenus",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuTitle = table.Column<string>(maxLength: 50, nullable: false),
                    Link = table.Column<string>(maxLength: 250, nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(maxLength: 150, nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainMenus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_MainMenus_MainMenus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MainMenus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainMenus_ParentId",
                table: "MainMenus",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainMenus");
        }
    }
}
