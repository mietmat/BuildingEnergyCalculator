using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class newName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Windows",
                newName: "SingleArea");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Doors",
                newName: "SingleArea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SingleArea",
                table: "Windows",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "SingleArea",
                table: "Doors",
                newName: "Area");
        }
    }
}
