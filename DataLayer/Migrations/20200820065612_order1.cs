using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class order1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Sellers_GuaranteeId",
                table: "Variants");

            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Guarantees_GuaranteeId1",
                table: "Variants");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantVoteDetial_ShipmentDetails_ShipmentDetailId",
                table: "VariantVoteDetial");

            migrationBuilder.DropIndex(
                name: "IX_Variants_GuaranteeId1",
                table: "Variants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantVoteDetial",
                table: "VariantVoteDetial");

            migrationBuilder.DropColumn(
                name: "GuaranteeId1",
                table: "Variants");

            migrationBuilder.RenameTable(
                name: "VariantVoteDetial",
                newName: "VariantVoteDetials");

            migrationBuilder.RenameIndex(
                name: "IX_VariantVoteDetial_ShipmentDetailId",
                table: "VariantVoteDetials",
                newName: "IX_VariantVoteDetials_ShipmentDetailId");

            migrationBuilder.AddColumn<int>(
                name: "VariantId",
                table: "Carts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantVoteDetials",
                table: "VariantVoteDetials",
                column: "VariantVoteDetialId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_SellerId",
                table: "Variants",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_VariantId",
                table: "Carts",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Variants_VariantId",
                table: "Carts",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "VariantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Guarantees_GuaranteeId",
                table: "Variants",
                column: "GuaranteeId",
                principalTable: "Guarantees",
                principalColumn: "GuaranteeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Sellers_SellerId",
                table: "Variants",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VariantVoteDetials_ShipmentDetails_ShipmentDetailId",
                table: "VariantVoteDetials",
                column: "ShipmentDetailId",
                principalTable: "ShipmentDetails",
                principalColumn: "ShipmentDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Variants_VariantId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Guarantees_GuaranteeId",
                table: "Variants");

            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Sellers_SellerId",
                table: "Variants");

            migrationBuilder.DropForeignKey(
                name: "FK_VariantVoteDetials_ShipmentDetails_ShipmentDetailId",
                table: "VariantVoteDetials");

            migrationBuilder.DropIndex(
                name: "IX_Variants_SellerId",
                table: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_Carts_VariantId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantVoteDetials",
                table: "VariantVoteDetials");

            migrationBuilder.DropColumn(
                name: "VariantId",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "VariantVoteDetials",
                newName: "VariantVoteDetial");

            migrationBuilder.RenameIndex(
                name: "IX_VariantVoteDetials_ShipmentDetailId",
                table: "VariantVoteDetial",
                newName: "IX_VariantVoteDetial_ShipmentDetailId");

            migrationBuilder.AddColumn<int>(
                name: "GuaranteeId1",
                table: "Variants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantVoteDetial",
                table: "VariantVoteDetial",
                column: "VariantVoteDetialId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_GuaranteeId1",
                table: "Variants",
                column: "GuaranteeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Sellers_GuaranteeId",
                table: "Variants",
                column: "GuaranteeId",
                principalTable: "Sellers",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Guarantees_GuaranteeId1",
                table: "Variants",
                column: "GuaranteeId1",
                principalTable: "Guarantees",
                principalColumn: "GuaranteeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VariantVoteDetial_ShipmentDetails_ShipmentDetailId",
                table: "VariantVoteDetial",
                column: "ShipmentDetailId",
                principalTable: "ShipmentDetails",
                principalColumn: "ShipmentDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
