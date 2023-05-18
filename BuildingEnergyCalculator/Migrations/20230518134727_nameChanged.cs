using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class nameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perimiter",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "Perimiter",
                table: "Doors");

            migrationBuilder.RenameColumn(
                name: "λ",
                table: "Windows",
                newName: "Perimeter");

            migrationBuilder.RenameColumn(
                name: "λ",
                table: "Doors",
                newName: "Perimeter");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "Windows",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                table: "Doors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Perimeter",
                table: "Windows",
                newName: "λ");

            migrationBuilder.RenameColumn(
                name: "Perimeter",
                table: "Doors",
                newName: "λ");

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Windows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Perimiter",
                table: "Windows",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Floor",
                table: "Doors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Perimiter",
                table: "Doors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
