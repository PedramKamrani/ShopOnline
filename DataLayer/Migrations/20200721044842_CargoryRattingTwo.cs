using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CargoryRattingTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRatings_RatingAttributs_RatingTitleRatingAttributeId",
                table: "CategoryRatings");

            migrationBuilder.DropIndex(
                name: "IX_CategoryRatings_RatingTitleRatingAttributeId",
                table: "CategoryRatings");

            migrationBuilder.DropColumn(
                name: "RatingTitleRatingAttributeId",
                table: "CategoryRatings");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRatings_RatingAttributeId",
                table: "CategoryRatings",
                column: "RatingAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRatings_RatingAttributs_RatingAttributeId",
                table: "CategoryRatings",
                column: "RatingAttributeId",
                principalTable: "RatingAttributs",
                principalColumn: "RatingAttributeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRatings_RatingAttributs_RatingAttributeId",
                table: "CategoryRatings");

            migrationBuilder.DropIndex(
                name: "IX_CategoryRatings_RatingAttributeId",
                table: "CategoryRatings");

            migrationBuilder.AddColumn<int>(
                name: "RatingTitleRatingAttributeId",
                table: "CategoryRatings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRatings_RatingTitleRatingAttributeId",
                table: "CategoryRatings",
                column: "RatingTitleRatingAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRatings_RatingAttributs_RatingTitleRatingAttributeId",
                table: "CategoryRatings",
                column: "RatingTitleRatingAttributeId",
                principalTable: "RatingAttributs",
                principalColumn: "RatingAttributeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
