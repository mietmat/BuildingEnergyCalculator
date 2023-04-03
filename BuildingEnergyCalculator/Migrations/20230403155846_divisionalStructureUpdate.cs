using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class divisionalStructureUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingMaterials_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "DivisionalStructureId",
                table: "BuildingMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingMaterials_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterials",
                column: "DivisionalStructureId",
                principalTable: "DivisionalStructures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingMaterials_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "DivisionalStructureId",
                table: "BuildingMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingMaterials_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterials",
                column: "DivisionalStructureId",
                principalTable: "DivisionalStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
