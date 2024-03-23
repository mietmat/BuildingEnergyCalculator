using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class perimeterNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerimiterOfTheBuilding",
                table: "BuildingParameters",
                newName: "PerimeterOfTheBuilding");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerimeterOfTheBuilding",
                table: "BuildingParameters",
                newName: "PerimiterOfTheBuilding");
        }
    }
}
