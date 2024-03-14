using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class projectEntitiesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModels_BuildingObjects_BuildingObjectId",
                table: "ProjectModels");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingObjectId",
                table: "ProjectModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModels_BuildingObjects_BuildingObjectId",
                table: "ProjectModels",
                column: "BuildingObjectId",
                principalTable: "BuildingObjects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModels_BuildingObjects_BuildingObjectId",
                table: "ProjectModels");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingObjectId",
                table: "ProjectModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModels_BuildingObjects_BuildingObjectId",
                table: "ProjectModels",
                column: "BuildingObjectId",
                principalTable: "BuildingObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
