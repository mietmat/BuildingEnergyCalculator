using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_BuildingParameters_BuildingParametersId",
                table: "Investments");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingParametersId",
                table: "Investments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_BuildingParameters_BuildingParametersId",
                table: "Investments",
                column: "BuildingParametersId",
                principalTable: "BuildingParameters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_BuildingParameters_BuildingParametersId",
                table: "Investments");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingParametersId",
                table: "Investments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_BuildingParameters_BuildingParametersId",
                table: "Investments",
                column: "BuildingParametersId",
                principalTable: "BuildingParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
