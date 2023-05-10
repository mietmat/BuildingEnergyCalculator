using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingDescription",
                table: "BuildingParameters");

            migrationBuilder.DropColumn(
                name: "BuildingName",
                table: "BuildingParameters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
