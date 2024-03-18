using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class addedProjectId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_BuildingObjects_BuildingObjectId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_BuildingObjectId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "BuildingObjectId",
                table: "Solutions");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Solutions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Solutions");

            migrationBuilder.AddColumn<int>(
                name: "BuildingObjectId",
                table: "Solutions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_BuildingObjectId",
                table: "Solutions",
                column: "BuildingObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_BuildingObjects_BuildingObjectId",
                table: "Solutions",
                column: "BuildingObjectId",
                principalTable: "BuildingObjects",
                principalColumn: "Id");
        }
    }
}
