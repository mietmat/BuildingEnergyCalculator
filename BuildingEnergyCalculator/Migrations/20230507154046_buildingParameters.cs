using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class buildingParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingLengthN = table.Column<double>(type: "float", nullable: false),
                    BuildingLengthE = table.Column<double>(type: "float", nullable: false),
                    BuildingLengthS = table.Column<double>(type: "float", nullable: false),
                    BuildingLengthW = table.Column<double>(type: "float", nullable: false),
                    StoreyHeightNet = table.Column<double>(type: "float", nullable: false),
                    StoreyHeightGross = table.Column<double>(type: "float", nullable: false),
                    CellarHeight = table.Column<double>(type: "float", nullable: false),
                    StoreyQuantity = table.Column<int>(type: "int", nullable: false),
                    BuildingArea = table.Column<double>(type: "float", nullable: false),
                    StaircaseSurface = table.Column<double>(type: "float", nullable: false),
                    UsableAreaOfTheStairCase = table.Column<double>(type: "float", nullable: false),
                    StaircaseWidth = table.Column<double>(type: "float", nullable: false),
                    HeatAtticArea = table.Column<double>(type: "float", nullable: false),
                    UnheatedAtticArea = table.Column<double>(type: "float", nullable: false),
                    UsableAreaOfTheBuilding = table.Column<double>(type: "float", nullable: false),
                    AtticUsableArea = table.Column<double>(type: "float", nullable: false),
                    PerimiterOfTheBuilding = table.Column<double>(type: "float", nullable: false),
                    BalconyLength = table.Column<double>(type: "float", nullable: false),
                    TotalWindowAreaN = table.Column<double>(type: "float", nullable: false),
                    TotalWindowAreaE = table.Column<double>(type: "float", nullable: false),
                    TotalWindowAreaS = table.Column<double>(type: "float", nullable: false),
                    TotalWindowAreaW = table.Column<double>(type: "float", nullable: false),
                    TotalDoorAreaN = table.Column<double>(type: "float", nullable: false),
                    TotalDoorAreaE = table.Column<double>(type: "float", nullable: false),
                    TotalDoorAreaS = table.Column<double>(type: "float", nullable: false),
                    TotalDoorAreaW = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingParametersId = table.Column<int>(type: "int", nullable: true),
                    BuildingParametersId1 = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Perimiter = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    U = table.Column<double>(type: "float", nullable: false),
                    CardinalDirection = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doors_BuildingParameters_BuildingParametersId",
                        column: x => x.BuildingParametersId,
                        principalTable: "BuildingParameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doors_BuildingParameters_BuildingParametersId1",
                        column: x => x.BuildingParametersId1,
                        principalTable: "BuildingParameters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingParametersId = table.Column<int>(type: "int", nullable: true),
                    BuildingParametersId1 = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Perimiter = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    U = table.Column<double>(type: "float", nullable: false),
                    CardinalDirection = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Windows_BuildingParameters_BuildingParametersId",
                        column: x => x.BuildingParametersId,
                        principalTable: "BuildingParameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Windows_BuildingParameters_BuildingParametersId1",
                        column: x => x.BuildingParametersId1,
                        principalTable: "BuildingParameters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doors_BuildingParametersId",
                table: "Doors",
                column: "BuildingParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_BuildingParametersId1",
                table: "Doors",
                column: "BuildingParametersId1");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_BuildingParametersId",
                table: "Windows",
                column: "BuildingParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_BuildingParametersId1",
                table: "Windows",
                column: "BuildingParametersId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "BuildingParameters");
        }
    }
}
