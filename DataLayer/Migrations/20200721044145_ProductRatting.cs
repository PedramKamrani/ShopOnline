using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ProductRatting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_RatingAttributeId",
                table: "ProductReviewRatings");

            migrationBuilder.AddColumn<int>(
                name: "CategoryRatingId",
                table: "ProductReviewRatings",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviewRatings_RatingAttributs_RatingAttributeId",
                table: "ProductReviewRatings",
                column: "RatingAttributeId",
                principalTable: "RatingAttributs",
                principalColumn: "RatingAttributeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviewRatings_RatingAttributs_RatingAttributeId",
                table: "ProductReviewRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviewRatings_CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.DropColumn(
                name: "CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_RatingAttributeId",
                table: "ProductReviewRatings",
                column: "RatingAttributeId",
                principalTable: "CategoryRatings",
                principalColumn: "CategoryRatingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
