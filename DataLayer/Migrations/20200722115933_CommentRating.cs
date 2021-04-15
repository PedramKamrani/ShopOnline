using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CommentRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentRatings",
                columns: table => new
                {
                    CommentRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    RatingAttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRatings", x => x.CommentRatingId);
                    table.ForeignKey(
                        name: "FK_CommentRatings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentRatings_RatingAttributs_RatingAttributeId",
                        column: x => x.RatingAttributeId,
                        principalTable: "RatingAttributs",
                        principalColumn: "RatingAttributeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentRatings_ProductId",
                table: "CommentRatings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRatings_RatingAttributeId",
                table: "CommentRatings",
                column: "RatingAttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentRatings");
        }
    }
}
