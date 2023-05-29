using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class groundOnTheFloor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FloorOnTheGround",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ag = table.Column<double>(type: "float", nullable: false),
                    P = table.Column<double>(type: "float", nullable: false),
                    B = table.Column<double>(type: "float", nullable: false),
                    GroundMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    λgr = table.Column<double>(type: "float", nullable: false),
                    w = table.Column<double>(type: "float", nullable: false),
                    df = table.Column<double>(type: "float", nullable: false),
                    λf = table.Column<double>(type: "float", nullable: false),
                    Rf = table.Column<double>(type: "float", nullable: false),
                    dt = table.Column<double>(type: "float", nullable: false),
                    Ugr = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorOnTheGround", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FloorOnTheGround");
        }
    }
}
