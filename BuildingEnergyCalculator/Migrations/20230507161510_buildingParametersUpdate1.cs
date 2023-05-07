using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class buildingParametersUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doors_BuildingParameters_BuildingParametersId",
                table: "Doors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doors_BuildingParameters_BuildingParametersId1",
                table: "Doors");

            migrationBuilder.DropForeignKey(
                name: "FK_Windows_BuildingParameters_BuildingParametersId",
                table: "Windows");

            migrationBuilder.DropForeignKey(
                name: "FK_Windows_BuildingParameters_BuildingParametersId1",
                table: "Windows");

            migrationBuilder.DropIndex(
                name: "IX_Windows_BuildingParametersId",
                table: "Windows");

            migrationBuilder.DropIndex(
                name: "IX_Windows_BuildingParametersId1",
                table: "Windows");

            migrationBuilder.DropIndex(
                name: "IX_Doors_BuildingParametersId",
                table: "Doors");

            migrationBuilder.DropIndex(
                name: "IX_Doors_BuildingParametersId1",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "BuildingParametersId",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "BuildingParametersId1",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "BuildingParametersId",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "BuildingParametersId1",
                table: "Doors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingParametersId",
                table: "Windows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingParametersId1",
                table: "Windows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingParametersId",
                table: "Doors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingParametersId1",
                table: "Doors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Windows_BuildingParametersId",
                table: "Windows",
                column: "BuildingParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_BuildingParametersId1",
                table: "Windows",
                column: "BuildingParametersId1");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_BuildingParametersId",
                table: "Doors",
                column: "BuildingParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_BuildingParametersId1",
                table: "Doors",
                column: "BuildingParametersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_BuildingParameters_BuildingParametersId",
                table: "Doors",
                column: "BuildingParametersId",
                principalTable: "BuildingParameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_BuildingParameters_BuildingParametersId1",
                table: "Doors",
                column: "BuildingParametersId1",
                principalTable: "BuildingParameters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_BuildingParameters_BuildingParametersId",
                table: "Windows",
                column: "BuildingParametersId",
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
