using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class divStructuretest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionalStructureId",
                table: "BuildingMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "LayerThickness",
                table: "BuildingMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "DivisionalStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionalThickness = table.Column<double>(type: "float", nullable: false),
                    λ = table.Column<double>(type: "float", nullable: false),
                    R = table.Column<double>(type: "float", nullable: false),
                    U = table.Column<double>(type: "float", nullable: false),
                    Rsi = table.Column<double>(type: "float", nullable: false),
                    Rse = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionalStructures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingMaterials_DivisionalStructureId",
                table: "BuildingMaterials",
                column: "DivisionalStructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingMaterials_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterials",
                column: "DivisionalStructureId",
                principalTable: "DivisionalStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingMaterials_DivisionalStructures_DivisionalStructureId",
                table: "BuildingMaterials");

            migrationBuilder.DropTable(
                name: "DivisionalStructures");

            migrationBuilder.DropIndex(
                name: "IX_BuildingMaterials_DivisionalStructureId",
                table: "BuildingMaterials");

            migrationBuilder.DropColumn(
                name: "DivisionalStructureId",
                table: "BuildingMaterials");

            migrationBuilder.DropColumn(
                name: "LayerThickness",
                table: "BuildingMaterials");
        }
    }
}
