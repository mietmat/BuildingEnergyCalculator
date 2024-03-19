using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class AddedSolutionsIntoProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectModelId",
                table: "Solutions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_ProjectModelId",
                table: "Solutions",
                column: "ProjectModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_ProjectModels_ProjectModelId",
                table: "Solutions",
                column: "ProjectModelId",
                principalTable: "ProjectModels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_ProjectModels_ProjectModelId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_ProjectModelId",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "Solutions");
        }
    }
}
