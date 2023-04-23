using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class RenamePropBuildingMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GammaW",
                table: "BuildingMaterials",
                newName: "λ");

            migrationBuilder.RenameColumn(
                name: "GammaSW",
                table: "BuildingMaterials",
                newName: "R");

            migrationBuilder.AddColumn<double>(
                name: "LambdaSW",
                table: "BuildingMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LambdaW",
                table: "BuildingMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LambdaSW",
                table: "BuildingMaterials");

            migrationBuilder.DropColumn(
                name: "LambdaW",
                table: "BuildingMaterials");

            migrationBuilder.RenameColumn(
                name: "λ",
                table: "BuildingMaterials",
                newName: "GammaW");

            migrationBuilder.RenameColumn(
                name: "R",
                table: "BuildingMaterials",
                newName: "GammaSW");
        }
    }
}
