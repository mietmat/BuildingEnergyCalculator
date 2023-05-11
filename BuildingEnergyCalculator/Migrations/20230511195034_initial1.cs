using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LambdaSW = table.Column<double>(type: "float", nullable: false),
                    LambdaW = table.Column<double>(type: "float", nullable: false),
                    λ = table.Column<double>(type: "float", nullable: false),
                    Ro = table.Column<double>(type: "float", nullable: false),
                    R = table.Column<double>(type: "float", nullable: false),
                    Cw = table.Column<double>(type: "float", nullable: false),
                    Thickness = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "DivisionalStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionalThickness = table.Column<double>(type: "float", nullable: false),
                    RSum = table.Column<double>(type: "float", nullable: false),
                    U = table.Column<double>(type: "float", nullable: false),
                    Rsi = table.Column<double>(type: "float", nullable: false),
                    Rse = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionalStructures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investors_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingParametersId = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Perimiter = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    U = table.Column<double>(type: "float", nullable: false),
                    λ = table.Column<double>(type: "float", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingParametersId = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Perimiter = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    U = table.Column<double>(type: "float", nullable: false),
                    λ = table.Column<double>(type: "float", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "BuildingMaterialDivisionalStructures",
                columns: table => new
                {
                    BuildingMaterialId = table.Column<int>(type: "int", nullable: false),
                    DivisionalStructureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingMaterialDivisionalStructures", x => new { x.DivisionalStructureId, x.BuildingMaterialId });
                    table.ForeignKey(
                        name: "FK_BuildingMaterialDivisionalStructures_BuildingMaterials_BuildingMaterialId",
                        column: x => x.BuildingMaterialId,
                        principalTable: "BuildingMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingMaterialDivisionalStructures_DivisionalStructures_DivisionalStructureId",
                        column: x => x.DivisionalStructureId,
                        principalTable: "DivisionalStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpireTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordExpiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    InvestorId = table.Column<int>(type: "int", nullable: true),
                    BuildingParametersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingInformation_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingInformation_BuildingParameters_BuildingParametersId",
                        column: x => x.BuildingParametersId,
                        principalTable: "BuildingParameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuildingInformation_Investors_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "Investors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInformation_AddressId",
                table: "BuildingInformation",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInformation_BuildingParametersId",
                table: "BuildingInformation",
                column: "BuildingParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInformation_InvestorId",
                table: "BuildingInformation",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingMaterialDivisionalStructures_BuildingMaterialId",
                table: "BuildingMaterialDivisionalStructures",
                column: "BuildingMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_BuildingParametersId",
                table: "Doors",
                column: "BuildingParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Investors_AddressId",
                table: "Investors",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_BuildingParametersId",
                table: "Windows",
                column: "BuildingParametersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingInformation");

            migrationBuilder.DropTable(
                name: "BuildingMaterialDivisionalStructures");

            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "Investors");

            migrationBuilder.DropTable(
                name: "BuildingMaterials");

            migrationBuilder.DropTable(
                name: "DivisionalStructures");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BuildingParameters");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
