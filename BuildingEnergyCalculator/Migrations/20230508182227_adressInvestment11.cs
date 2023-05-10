using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class adressInvestment11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingDescription",
                table: "Investment");

            migrationBuilder.DropColumn(
                name: "BuildingName",
                table: "Investment");

            migrationBuilder.AddColumn<string>(
                name: "BuildingDescription",
                table: "BuildingParameters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuildingName",
                table: "BuildingParameters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingDescription",
                table: "BuildingParameters");

            migrationBuilder.DropColumn(
                name: "BuildingName",
                table: "BuildingParameters");

            migrationBuilder.AddColumn<string>(
                name: "BuildingDescription",
                table: "Investment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuildingName",
                table: "Investment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
