using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CargoryRatting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviewRatings_CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.DropColumn(
                name: "CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRatings_CategoryId",
                table: "CategoryRatings",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRatings_Categories_CategoryId",
                table: "CategoryRatings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRatings_Categories_CategoryId",
                table: "CategoryRatings");

            migrationBuilder.DropIndex(
                name: "IX_CategoryRatings_CategoryId",
                table: "CategoryRatings");

            migrationBuilder.AddColumn<int>(
                name: "CategoryRatingId",
                table: "ProductReviewRatings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_CategoryRatingId",
                table: "ProductReviewRatings",
                column: "CategoryRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_CategoryRatingId",
                table: "ProductReviewRatings",
                column: "CategoryRatingId",
                principalTable: "CategoryRatings",
                principalColumn: "CategoryRatingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
