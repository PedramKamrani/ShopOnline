using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class RatingAttributs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRatings_RatingTitles_RatingTitleRatingAttributeId",
                table: "CategoryRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviewRatings_Products_ProductsProductId",
                table: "ProductReviewRatings");

            migrationBuilder.DropTable(
                name: "RatingTitles");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviewRatings_CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviewRatings_ProductsProductId",
                table: "ProductReviewRatings");

            migrationBuilder.DropColumn(
                name: "CategoryRatingId",
                table: "ProductReviewRatings");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "ProductReviewRatings");

            migrationBuilder.CreateTable(
                name: "RatingAttributs",
                columns: table => new
                {
                    RatingAttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingAttributs", x => x.RatingAttributeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_ProductId",
                table: "ProductReviewRatings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_RatingAttributeId",
                table: "ProductReviewRatings",
                column: "RatingAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRatings_RatingAttributs_RatingTitleRatingAttributeId",
                table: "CategoryRatings",
                column: "RatingTitleRatingAttributeId",
                principalTable: "RatingAttributs",
                principalColumn: "RatingAttributeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviewRatings_Products_ProductId",
                table: "ProductReviewRatings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_RatingAttributeId",
                table: "ProductReviewRatings",
                column: "RatingAttributeId",
                principalTable: "CategoryRatings",
                principalColumn: "CategoryRatingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRatings_RatingAttributs_RatingTitleRatingAttributeId",
                table: "CategoryRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviewRatings_Products_ProductId",
                table: "ProductReviewRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_RatingAttributeId",
                table: "ProductReviewRatings");

            migrationBuilder.DropTable(
                name: "RatingAttributs");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviewRatings_ProductId",
                table: "ProductReviewRatings");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviewRatings_RatingAttributeId",
                table: "ProductReviewRatings");

            migrationBuilder.AddColumn<int>(
                name: "CategoryRatingId",
                table: "ProductReviewRatings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "ProductReviewRatings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RatingTitles",
                columns: table => new
                {
                    RatingAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingTitles", x => x.RatingAttributeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_CategoryRatingId",
                table: "ProductReviewRatings",
                column: "CategoryRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_ProductsProductId",
                table: "ProductReviewRatings",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRatings_RatingTitles_RatingTitleRatingAttributeId",
                table: "CategoryRatings",
                column: "RatingTitleRatingAttributeId",
                principalTable: "RatingTitles",
                principalColumn: "RatingAttributeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviewRatings_CategoryRatings_CategoryRatingId",
                table: "ProductReviewRatings",
                column: "CategoryRatingId",
                principalTable: "CategoryRatings",
                principalColumn: "CategoryRatingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviewRatings_Products_ProductsProductId",
                table: "ProductReviewRatings",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
