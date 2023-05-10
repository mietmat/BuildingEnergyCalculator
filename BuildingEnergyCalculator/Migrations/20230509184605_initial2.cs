using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingParametersId",
                table: "Investments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Investments_BuildingParametersId",
                table: "Investments",
                column: "BuildingParametersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_BuildingParameters_BuildingParametersId",
                table: "Investments",
                column: "BuildingParametersId",
                principalTable: "BuildingParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_BuildingParameters_BuildingParametersId",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Investments_BuildingParametersId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "BuildingParametersId",
                table: "Investments");
        }
    }
}
