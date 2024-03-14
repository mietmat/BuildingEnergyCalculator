using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class projectEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingInformationId = table.Column<int>(type: "int", nullable: false),
                    DivisionalStructureId = table.Column<int>(type: "int", nullable: false),
                    BuildingParametersId = table.Column<int>(type: "int", nullable: false),
                    FloorOnTheGroundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingObjects_BuildingInformation_BuildingInformationId",
                        column: x => x.BuildingInformationId,
                        principalTable: "BuildingInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingObjects_BuildingParameters_BuildingParametersId",
                        column: x => x.BuildingParametersId,
                        principalTable: "BuildingParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingObjects_DivisionalStructures_DivisionalStructureId",
                        column: x => x.DivisionalStructureId,
                        principalTable: "DivisionalStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingObjects_FloorOnTheGround_FloorOnTheGroundId",
                        column: x => x.FloorOnTheGroundId,
                        principalTable: "FloorOnTheGround",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModels_BuildingObjects_BuildingObjectId",
                        column: x => x.BuildingObjectId,
                        principalTable: "BuildingObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingObjects_BuildingInformationId",
                table: "BuildingObjects",
                column: "BuildingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingObjects_BuildingParametersId",
                table: "BuildingObjects",
                column: "BuildingParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingObjects_DivisionalStructureId",
                table: "BuildingObjects",
                column: "DivisionalStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingObjects_FloorOnTheGroundId",
                table: "BuildingObjects",
                column: "FloorOnTheGroundId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModels_BuildingObjectId",
                table: "ProjectModels",
                column: "BuildingObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectModels");

            migrationBuilder.DropTable(
                name: "BuildingObjects");
        }
    }
}
