using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class foreighKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investors_Addresses_AddressId",
                table: "Investors");

            migrationBuilder.DropIndex(
                name: "IX_Investors_AddressId",
                table: "Investors");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Investors");

            migrationBuilder.AddColumn<int>(
                name: "InvestorId",
                table: "Investments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvestorId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Investments_InvestorId",
                table: "Investments",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_InvestorId",
                table: "Addresses",
                column: "InvestorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Investors_InvestorId",
                table: "Addresses",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Investors_InvestorId",
                table: "Investments",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Investors_InvestorId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Investors_InvestorId",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Investments_InvestorId",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_InvestorId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Investors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Investors_AddressId",
                table: "Investors",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investors_Addresses_AddressId",
                table: "Investors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
