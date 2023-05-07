using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class buildingParametersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BuildingParameters",
                newName: "BuildingName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "BuildingParameters",
                newName: "BuildingDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingName",
                table: "BuildingParameters",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BuildingDescription",
                table: "BuildingParameters",
                newName: "Description");
        }
    }
}
