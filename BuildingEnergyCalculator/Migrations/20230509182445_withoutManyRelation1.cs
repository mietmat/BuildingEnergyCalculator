using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class withoutManyRelation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Investments_InvestmentId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Investors_InvestorId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_InvestmentId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_InvestorId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InvestmentId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Investors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InvestorId",
                table: "Investments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Investments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Investors_AddressId",
                table: "Investors",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_AddressId",
                table: "Investments",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Addresses_AddressId",
                table: "Investments",
                column: "AddressId",
                principalTable: "Addresses",
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
                name: "FK_Investments_Addresses_AddressId",
                table: "Investments");

            migrationBuilder.DropForeignKey(
                name: "FK_Investors_Addresses_AddressId",
                table: "Investors");

            migrationBuilder.DropIndex(
                name: "IX_Investors_AddressId",
                table: "Investors");

            migrationBuilder.DropIndex(
                name: "IX_Investments_AddressId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Investors");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Investments");

            migrationBuilder.AlterColumn<int>(
                name: "InvestorId",
                table: "Investments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvestmentId",
                table: "Addresses",
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
                name: "IX_Addresses_InvestmentId",
                table: "Addresses",
                column: "InvestmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_InvestorId",
                table: "Addresses",
                column: "InvestorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Investments_InvestmentId",
                table: "Addresses",
                column: "InvestmentId",
                principalTable: "Investments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Investors_InvestorId",
                table: "Addresses",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
