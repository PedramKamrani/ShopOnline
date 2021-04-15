using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class proprtytwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValues_ProprtyNames_ProprtyNamePropertyNameId",
                table: "PropertyValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProprtyNames_ProprtyGroups_ProprtyGroupPropertyGroupId",
                table: "ProprtyNames");

            migrationBuilder.DropIndex(
                name: "IX_ProprtyNames_ProprtyGroupPropertyGroupId",
                table: "ProprtyNames");

            migrationBuilder.DropIndex(
                name: "IX_PropertyValues_ProprtyNamePropertyNameId",
                table: "PropertyValues");

            migrationBuilder.DropColumn(
                name: "ProprtyGroupPropertyGroupId",
                table: "ProprtyNames");

            migrationBuilder.DropColumn(
                name: "ProprtyNamePropertyNameId",
                table: "PropertyValues");

            migrationBuilder.CreateIndex(
                name: "IX_ProprtyNames_PropertyGroupId",
                table: "ProprtyNames",
                column: "PropertyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyValues_PropertyNameId",
                table: "PropertyValues",
                column: "PropertyNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValues_ProprtyNames_PropertyNameId",
                table: "PropertyValues",
                column: "PropertyNameId",
                principalTable: "ProprtyNames",
                principalColumn: "PropertyNameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProprtyNames_ProprtyGroups_PropertyGroupId",
                table: "ProprtyNames",
                column: "PropertyGroupId",
                principalTable: "ProprtyGroups",
                principalColumn: "PropertyGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValues_ProprtyNames_PropertyNameId",
                table: "PropertyValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProprtyNames_ProprtyGroups_PropertyGroupId",
                table: "ProprtyNames");

            migrationBuilder.DropIndex(
                name: "IX_ProprtyNames_PropertyGroupId",
                table: "ProprtyNames");

            migrationBuilder.DropIndex(
                name: "IX_PropertyValues_PropertyNameId",
                table: "PropertyValues");

            migrationBuilder.AddColumn<int>(
                name: "ProprtyGroupPropertyGroupId",
                table: "ProprtyNames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProprtyNamePropertyNameId",
                table: "PropertyValues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProprtyNames_ProprtyGroupPropertyGroupId",
                table: "ProprtyNames",
                column: "ProprtyGroupPropertyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyValues_ProprtyNamePropertyNameId",
                table: "PropertyValues",
                column: "ProprtyNamePropertyNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValues_ProprtyNames_ProprtyNamePropertyNameId",
                table: "PropertyValues",
                column: "ProprtyNamePropertyNameId",
                principalTable: "ProprtyNames",
                principalColumn: "PropertyNameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProprtyNames_ProprtyGroups_ProprtyGroupPropertyGroupId",
                table: "ProprtyNames",
                column: "ProprtyGroupPropertyGroupId",
                principalTable: "ProprtyGroups",
                principalColumn: "PropertyGroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
