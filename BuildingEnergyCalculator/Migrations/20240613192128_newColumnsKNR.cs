using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class newColumnsKNR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KNRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KNRNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KNRName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KNRs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KNRMachine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkLoad = table.Column<double>(type: "float", nullable: false),
                    KNRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KNRMachine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KNRMachine_KNRs_KNRId",
                        column: x => x.KNRId,
                        principalTable: "KNRs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KNRMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkLoad = table.Column<double>(type: "float", nullable: false),
                    KNRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KNRMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KNRMaterial_KNRs_KNRId",
                        column: x => x.KNRId,
                        principalTable: "KNRs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Labor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KNRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labor_KNRs_KNRId",
                        column: x => x.KNRId,
                        principalTable: "KNRs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkLoad = table.Column<double>(type: "float", nullable: false),
                    KNRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupation_KNRs_KNRId",
                        column: x => x.KNRId,
                        principalTable: "KNRs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KNRMachine_KNRId",
                table: "KNRMachine",
                column: "KNRId");

            migrationBuilder.CreateIndex(
                name: "IX_KNRMaterial_KNRId",
                table: "KNRMaterial",
                column: "KNRId");

            migrationBuilder.CreateIndex(
                name: "IX_Labor_KNRId",
                table: "Labor",
                column: "KNRId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupation_KNRId",
                table: "Occupation",
                column: "KNRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KNRMachine");

            migrationBuilder.DropTable(
                name: "KNRMaterial");

            migrationBuilder.DropTable(
                name: "Labor");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropTable(
                name: "KNRs");
        }
    }
}
