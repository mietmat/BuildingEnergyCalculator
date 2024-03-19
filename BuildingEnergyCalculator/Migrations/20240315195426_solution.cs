using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class solution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModels_BuildingObjects_BuildingObjectId",
                table: "ProjectModels");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModels_BuildingObjectId",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "BuildingObjectId",
                table: "ProjectModels");

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solutions_BuildingObjects_BuildingObjectId",
                        column: x => x.BuildingObjectId,
                        principalTable: "BuildingObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_BuildingObjectId",
                table: "Solutions",
                column: "BuildingObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.AddColumn<int>(
                name: "BuildingObjectId",
                table: "ProjectModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModels_BuildingObjectId",
                table: "ProjectModels",
                column: "BuildingObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModels_BuildingObjects_BuildingObjectId",
                table: "ProjectModels",
                column: "BuildingObjectId",
                principalTable: "BuildingObjects",
                principalColumn: "Id");
        }
    }
}
