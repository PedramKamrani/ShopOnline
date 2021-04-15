using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class orderB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VariantVoteDetial",
                columns: table => new
                {
                    VariantVoteDetialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vote = table.Column<byte>(nullable: false),
                    ShipmentDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantVoteDetial", x => x.VariantVoteDetialId);
                    table.ForeignKey(
                        name: "FK_VariantVoteDetial_ShipmentDetails_ShipmentDetailId",
                        column: x => x.ShipmentDetailId,
                        principalTable: "ShipmentDetails",
                        principalColumn: "ShipmentDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariantVoteDetial_ShipmentDetailId",
                table: "VariantVoteDetial",
                column: "ShipmentDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariantVoteDetial");
        }
    }
}
