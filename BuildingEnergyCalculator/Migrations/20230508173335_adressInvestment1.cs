using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class adressInvestment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Investor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvestorId",
                table: "Investment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Investor_AddressId",
                table: "Investor",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investor_Address_AddressId",
                table: "Investor",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investor_Address_AddressId",
                table: "Investor");

            migrationBuilder.DropIndex(
                name: "IX_Investor_AddressId",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Investment");
        }
    }
}
