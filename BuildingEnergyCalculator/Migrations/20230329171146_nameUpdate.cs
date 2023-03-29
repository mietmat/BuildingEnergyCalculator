using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class nameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BuldingMaterials",
                table: "BuldingMaterials");

            migrationBuilder.RenameTable(
                name: "BuldingMaterials",
                newName: "BuildingMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingMaterials",
                table: "BuildingMaterials",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingMaterials",
                table: "BuildingMaterials");

            migrationBuilder.RenameTable(
                name: "BuildingMaterials",
                newName: "BuldingMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuldingMaterials",
                table: "BuldingMaterials",
                column: "Id");
        }
    }
}
