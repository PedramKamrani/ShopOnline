using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ProductRatingReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaTitle = table.Column<string>(maxLength: 300, nullable: false),
                    EnTitle = table.Column<string>(maxLength: 300, nullable: false),
                    CreteDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    ImgName = table.Column<string>(maxLength: 100, nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    BrandID = table.Column<int>(nullable: false),
                    CategoresCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoresCategoryId",
                        column: x => x.CategoresCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RatingTitles",
                columns: table => new
                {
                    RatingAttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingTitles", x => x.RatingAttributeId);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgName = table.Column<string>(maxLength: 100, nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRaview",
                columns: table => new
                {
                    ProductReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(maxLength: 2000, nullable: true),
                    ShortReview = table.Column<string>(maxLength: 2000, nullable: true),
                    Review = table.Column<string>(nullable: true),
                    Positive = table.Column<string>(maxLength: 500, nullable: true),
                    Negative = table.Column<string>(maxLength: 500, nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductsProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRaview", x => x.ProductReviewId);
                    table.ForeignKey(
                        name: "FK_ProductRaview_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRatings",
                columns: table => new
                {
                    CategoryRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    RatingAttributeId = table.Column<int>(nullable: false),
                    RatingTitleRatingAttributeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRatings", x => x.CategoryRatingId);
                    table.ForeignKey(
                        name: "FK_CategoryRatings_RatingTitles_RatingTitleRatingAttributeId",
                        column: x => x.RatingTitleRatingAttributeId,
                        principalTable: "RatingTitles",
                        principalColumn: "RatingAttributeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviewRatings",
                columns: table => new
                {
                    ProductReviewRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    RatingAttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<byte>(nullable: false),
                    ProductsProductId = table.Column<int>(nullable: true),
                    CategoryRatingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviewRatings", x => x.ProductReviewRatingId);
                    table.ForeignKey(
                        name: "FK_ProductReviewRatings_CategoryRatings_CategoryRatingId",
                        column: x => x.CategoryRatingId,
                        principalTable: "CategoryRatings",
                        principalColumn: "CategoryRatingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReviewRatings_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRatings_RatingTitleRatingAttributeId",
                table: "CategoryRatings",
                column: "RatingTitleRatingAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRaview_ProductsProductId",
                table: "ProductRaview",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_CategoryRatingId",
                table: "ProductReviewRatings",
                column: "CategoryRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_ProductsProductId",
                table: "ProductReviewRatings",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoresCategoryId",
                table: "Products",
                column: "CategoresCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductRaview");

            migrationBuilder.DropTable(
                name: "ProductReviewRatings");

            migrationBuilder.DropTable(
                name: "CategoryRatings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RatingTitles");
        }
    }
}
