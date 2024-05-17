using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class buildingParametersId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingObjects_BuildingParameters_BuildingParametersId",
                table: "BuildingObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_ProjectModels_ProjectModelId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_ProjectModelId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_BuildingObjects_BuildingParametersId",
                table: "BuildingObjects");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "Solutions");

            migrationBuilder.AddColumn<int>(
                name: "BuildingObjectId",
                table: "Solutions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingObjectId",
                table: "Solutions");

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelId",
                table: "Solutions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_ProjectModelId",
                table: "Solutions",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingObjects_BuildingParametersId",
                table: "BuildingObjects",
                column: "BuildingParametersId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingObjects_BuildingParameters_BuildingParametersId",
                table: "BuildingObjects",
                column: "BuildingParametersId",
                principalTable: "BuildingParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_ProjectModels_ProjectModelId",
                table: "Solutions",
                column: "ProjectModelId",
                principalTable: "ProjectModels",
                principalColumn: "Id");
        }
    }
}
