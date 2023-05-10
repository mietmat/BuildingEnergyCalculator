using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doors_BuildingParameters_BuildingParametersId1",
                table: "Doors");

            migrationBuilder.DropForeignKey(
                name: "FK_Windows_BuildingParameters_BuildingParametersId1",
                table: "Windows");

            migrationBuilder.DropIndex(
                name: "IX_Windows_BuildingParametersId1",
                table: "Windows");

            migrationBuilder.DropIndex(
                name: "IX_Doors_BuildingParametersId1",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "BuildingParametersId1",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "BuildingParametersId1",
                table: "Doors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingParametersId1",
                table: "Windows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingParametersId1",
                table: "Doors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Windows_BuildingParametersId1",
                table: "Windows",
                column: "BuildingParametersId1");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_BuildingParametersId1",
                table: "Doors",
                column: "BuildingParametersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_BuildingParameters_BuildingParametersId1",
                table: "Doors",
                column: "BuildingParametersId1",
                principalTable: "BuildingParameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_BuildingParameters_BuildingParametersId1",
                table: "Windows",
                column: "BuildingParametersId1",
                principalTable: "BuildingParameters",
                principalColumn: "Id");
        }
    }
}
