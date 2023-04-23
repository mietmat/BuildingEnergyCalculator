using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class lazyLoading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingMaterialDivisionalStructure_BuildingMaterials_BuildingMaterialId",
                table: "BuildingMaterialDivisionalStructure");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingMaterialDivisionalStructure_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterialDivisionalStructure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingMaterialDivisionalStructure",
                table: "BuildingMaterialDivisionalStructure");

            migrationBuilder.RenameTable(
                name: "BuildingMaterialDivisionalStructure",
                newName: "BuildingMaterialDivisionalStructures");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingMaterialDivisionalStructure_BuildingMaterialId",
                table: "BuildingMaterialDivisionalStructures",
                newName: "IX_BuildingMaterialDivisionalStructures_BuildingMaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingMaterialDivisionalStructures",
                table: "BuildingMaterialDivisionalStructures",
                columns: new[] { "DivisionalStructureId", "BuildingMaterialId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingMaterialDivisionalStructures_BuildingMaterials_BuildingMaterialId",
                table: "BuildingMaterialDivisionalStructures",
                column: "BuildingMaterialId",
                principalTable: "BuildingMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingMaterialDivisionalStructures_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterialDivisionalStructures",
                column: "DivisionalStructureId",
                principalTable: "DivisionalStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingMaterialDivisionalStructures_BuildingMaterials_BuildingMaterialId",
                table: "BuildingMaterialDivisionalStructures");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingMaterialDivisionalStructures_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterialDivisionalStructures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingMaterialDivisionalStructures",
                table: "BuildingMaterialDivisionalStructures");

            migrationBuilder.RenameTable(
                name: "BuildingMaterialDivisionalStructures",
                newName: "BuildingMaterialDivisionalStructure");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingMaterialDivisionalStructures_BuildingMaterialId",
                table: "BuildingMaterialDivisionalStructure",
                newName: "IX_BuildingMaterialDivisionalStructure_BuildingMaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingMaterialDivisionalStructure",
                table: "BuildingMaterialDivisionalStructure",
                columns: new[] { "DivisionalStructureId", "BuildingMaterialId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingMaterialDivisionalStructure_BuildingMaterials_BuildingMaterialId",
                table: "BuildingMaterialDivisionalStructure",
                column: "BuildingMaterialId",
                principalTable: "BuildingMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingMaterialDivisionalStructure_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterialDivisionalStructure",
                column: "DivisionalStructureId",
                principalTable: "DivisionalStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
