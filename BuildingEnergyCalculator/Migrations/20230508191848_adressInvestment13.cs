using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class adressInvestment13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investment_Address_AddressId",
                table: "Investment");

            migrationBuilder.DropForeignKey(
                name: "FK_Investor_Address_AddressId",
                table: "Investor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investor",
                table: "Investor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investment",
                table: "Investment");

            migrationBuilder.DropIndex(
                name: "IX_Investment_AddressId",
                table: "Investment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Investment");

            migrationBuilder.RenameTable(
                name: "Investor",
                newName: "Investors");

            migrationBuilder.RenameTable(
                name: "Investment",
                newName: "Investments");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Investor_AddressId",
                table: "Investors",
                newName: "IX_Investors_AddressId");

            migrationBuilder.AddColumn<string>(
                name: "BuildingDescription",
                table: "Investments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuildingName",
                table: "Investments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InvestmentId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investors",
                table: "Investors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investments",
                table: "Investments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_InvestmentId",
                table: "Addresses",
                column: "InvestmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Investments_InvestmentId",
                table: "Addresses",
                column: "InvestmentId",
                principalTable: "Investments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investors_Addresses_AddressId",
                table: "Investors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Investments_InvestmentId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Investors_Addresses_AddressId",
                table: "Investors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investors",
                table: "Investors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investments",
                table: "Investments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_InvestmentId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "BuildingDescription",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "BuildingName",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "InvestmentId",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Investors",
                newName: "Investor");

            migrationBuilder.RenameTable(
                name: "Investments",
                newName: "Investment");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Investors_AddressId",
                table: "Investor",
                newName: "IX_Investor_AddressId");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Investment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investor",
                table: "Investor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investment",
                table: "Investment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Investment_AddressId",
                table: "Investment",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_Address_AddressId",
                table: "Investment",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Investor_Address_AddressId",
                table: "Investor",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
