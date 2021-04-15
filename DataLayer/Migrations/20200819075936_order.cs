using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coockie = table.Column<string>(maxLength: 200, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    ShippingType = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryCommsions",
                columns: table => new
                {
                    CategoryCommsionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<byte>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCommsions", x => x.CategoryCommsionId);
                    table.ForeignKey(
                        name: "FK_CategoryCommsions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCodes",
                columns: table => new
                {
                    DsicountCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    MinOrderAmount = table.Column<int>(nullable: true),
                    MaxUseCount = table.Column<int>(nullable: true),
                    ForFirstOrder = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodes", x => x.DsicountCodeId);
                    table.ForeignKey(
                        name: "FK_DiscountCodes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftCards",
                columns: table => new
                {
                    GiftCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Balance = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCards", x => x.GiftCardId);
                    table.ForeignKey(
                        name: "FK_GiftCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guarantees",
                columns: table => new
                {
                    GuaranteeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantees", x => x.GuaranteeId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientName = table.Column<string>(maxLength: 100, nullable: true),
                    RecipientTel = table.Column<string>(maxLength: 11, nullable: true),
                    RecipientAddress = table.Column<string>(maxLength: 150, nullable: true),
                    RecipientPostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    SumAmount = table.Column<int>(nullable: false),
                    AmountPayable = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PaymentStatus = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptions",
                columns: table => new
                {
                    ProductOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Value = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptions", x => x.ProductOptionId);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    DateProductAdd = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    CmpId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    BrandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.PromotionId);
                    table.ForeignKey(
                        name: "FK_Promotions_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promotions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 11, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    TimleySupply = table.Column<string>(maxLength: 4, nullable: true),
                    PostingWarranty = table.Column<string>(maxLength: 4, nullable: true),
                    NoReturend = table.Column<string>(maxLength: 4, nullable: true),
                    PurchaseConsent = table.Column<string>(maxLength: 4, nullable: true),
                    VoteCount = table.Column<int>(nullable: false),
                    Vote = table.Column<string>(nullable: true),
                    Balance = table.Column<long>(type: "bigint", nullable: false),
                    BalanceReceivable = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryTime = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "GiftCardTransactions",
                columns: table => new
                {
                    GiftCardTransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftCardId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCardTransactions", x => x.GiftCardTransactionId);
                    table.ForeignKey(
                        name: "FK_GiftCardTransactions_GiftCards_GiftCardId",
                        column: x => x.GiftCardId,
                        principalTable: "GiftCards",
                        principalColumn: "GiftCardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiftCardTransactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "paymentDetails",
                columns: table => new
                {
                    PaymentDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    RefIf = table.Column<string>(maxLength: 50, nullable: true),
                    DiscountCodeId = table.Column<int>(nullable: true),
                    GiftCartId = table.Column<int>(nullable: true),
                    GiftCardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentDetails", x => x.PaymentDetailId);
                    table.ForeignKey(
                        name: "FK_paymentDetails_DiscountCodes_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "DiscountCodes",
                        principalColumn: "DsicountCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_paymentDetails_GiftCards_GiftCardId",
                        column: x => x.GiftCardId,
                        principalTable: "GiftCards",
                        principalColumn: "GiftCardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_paymentDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipmments",
                columns: table => new
                {
                    ShipmmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<byte>(nullable: false),
                    SendDate = table.Column<DateTime>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    HowSend = table.Column<byte>(nullable: false),
                    PostalBarCode = table.Column<string>(nullable: true),
                    ShippingCost = table.Column<int>(nullable: false),
                    SumAmount = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipmments", x => x.ShipmmentId);
                    table.ForeignKey(
                        name: "FK_Shipmments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    VariantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    SepcialPrice = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    storeOnlineCount = table.Column<int>(nullable: false),
                    MaxOrderCount = table.Column<int>(nullable: true),
                    VoteCount = table.Column<int>(nullable: false),
                    PurchaseConsentPercent = table.Column<string>(nullable: true),
                    TotallySatisfied = table.Column<byte>(nullable: false),
                    Satisfied = table.Column<byte>(nullable: false),
                    Neutral = table.Column<byte>(nullable: false),
                    DisSatisfied = table.Column<int>(nullable: false),
                    TotallyDisSatisfied = table.Column<int>(nullable: false),
                    ReserveCount = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ProductOptionId = table.Column<int>(nullable: false),
                    GuaranteeId = table.Column<int>(nullable: false),
                    SellerId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    GuaranteeId1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_Variants_Sellers_GuaranteeId",
                        column: x => x.GuaranteeId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Variants_Guarantees_GuaranteeId1",
                        column: x => x.GuaranteeId1,
                        principalTable: "Guarantees",
                        principalColumn: "GuaranteeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Variants_ProductOptions_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOptions",
                        principalColumn: "ProductOptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartDetails",
                columns: table => new
                {
                    CartDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    IsActiveCart = table.Column<bool>(nullable: false),
                    VariantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.CartDetailId);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartDetails_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    ProductPriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    DiscountPrice = table.Column<int>(nullable: false),
                    DiscountPercent = table.Column<byte>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    VariantId = table.Column<int>(nullable: false),
                    ProductOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.ProductPriceId);
                    table.ForeignKey(
                        name: "FK_ProductPrices_ProductOptions_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOptions",
                        principalColumn: "ProductOptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleTransactions",
                columns: table => new
                {
                    SaleTransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    UnitDiscount = table.Column<int>(nullable: false),
                    SumPriceAfterDiscount = table.Column<int>(nullable: false),
                    VariantId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTransactions", x => x.SaleTransactionId);
                    table.ForeignKey(
                        name: "FK_SaleTransactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleTransactions_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentDetails",
                columns: table => new
                {
                    ShipmentDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    SumPrice = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    SumPriceAfterDiscount = table.Column<int>(nullable: false),
                    UnitDiscount = table.Column<int>(nullable: false),
                    StorePlace = table.Column<bool>(nullable: false),
                    DiscountType = table.Column<byte>(nullable: false),
                    VariantId = table.Column<int>(nullable: false),
                    ShipmmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentDetails", x => x.ShipmentDetailId);
                    table.ForeignKey(
                        name: "FK_ShipmentDetails_Shipmments_ShipmmentId",
                        column: x => x.ShipmmentId,
                        principalTable: "Shipmments",
                        principalColumn: "ShipmmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentDetails_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VariantPromotions",
                columns: table => new
                {
                    VariantPromotionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    Percent = table.Column<byte>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    MaxOrderCount = table.Column<int>(nullable: true),
                    ReminaingCount = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    VariantId = table.Column<int>(nullable: false),
                    PromotionId = table.Column<int>(nullable: false),
                    PromotionsPromotionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantPromotions", x => x.VariantPromotionId);
                    table.ForeignKey(
                        name: "FK_VariantPromotions_Promotions_PromotionsPromotionId",
                        column: x => x.PromotionsPromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VariantPromotions_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartId",
                table: "CartDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_VariantId",
                table: "CartDetails",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCommsions_CategoryId",
                table: "CategoryCommsions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodes_CategoryId",
                table: "DiscountCodes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCards_UserId",
                table: "GiftCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCardTransactions_GiftCardId",
                table: "GiftCardTransactions",
                column: "GiftCardId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCardTransactions_OrderId",
                table: "GiftCardTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentDetails_DiscountCodeId",
                table: "paymentDetails",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentDetails_GiftCardId",
                table: "paymentDetails",
                column: "GiftCardId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentDetails_OrderId",
                table: "paymentDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductOptionId",
                table: "ProductPrices",
                column: "ProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_VariantId",
                table: "ProductPrices",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BrandId",
                table: "Promotions",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CategoryId",
                table: "Promotions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_OrderId",
                table: "SaleTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_VariantId",
                table: "SaleTransactions",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_ShipmmentId",
                table: "ShipmentDetails",
                column: "ShipmmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_VariantId",
                table: "ShipmentDetails",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipmments_OrderId",
                table: "Shipmments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantPromotions_PromotionsPromotionId",
                table: "VariantPromotions",
                column: "PromotionsPromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantPromotions_VariantId",
                table: "VariantPromotions",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_GuaranteeId",
                table: "Variants",
                column: "GuaranteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_GuaranteeId1",
                table: "Variants",
                column: "GuaranteeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductOptionId",
                table: "Variants",
                column: "ProductOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDetails");

            migrationBuilder.DropTable(
                name: "CategoryCommsions");

            migrationBuilder.DropTable(
                name: "GiftCardTransactions");

            migrationBuilder.DropTable(
                name: "paymentDetails");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "SaleTransactions");

            migrationBuilder.DropTable(
                name: "ShipmentDetails");

            migrationBuilder.DropTable(
                name: "VariantPromotions");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "GiftCards");

            migrationBuilder.DropTable(
                name: "Shipmments");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Guarantees");

            migrationBuilder.DropTable(
                name: "ProductOptions");
        }
    }
}
