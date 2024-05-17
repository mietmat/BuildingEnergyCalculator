﻿// <auto-generated />
using System;
using BuildingEnergyCalculator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    [DbContext(typeof(EnergyCalculatorDbContext))]
    partial class EnergyCalculatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Library.BuildingMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Cw")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LambdaSW")
                        .HasColumnType("float");

                    b.Property<double>("LambdaW")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("R")
                        .HasColumnType("float");

                    b.Property<double>("Ro")
                        .HasColumnType("float");

                    b.Property<double>("Thickness")
                        .HasColumnType("float");

                    b.Property<double>("λ")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BuildingMaterials");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Library.BuildingMaterialDivisionalStructure", b =>
                {
                    b.Property<int>("DivisionalStructureId")
                        .HasColumnType("int");

                    b.Property<int>("BuildingMaterialId")
                        .HasColumnType("int");

                    b.HasKey("DivisionalStructureId", "BuildingMaterialId");

                    b.HasIndex("BuildingMaterialId");

                    b.ToTable("BuildingMaterialDivisionalStructures");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Library.Door", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BuildingParametersId")
                        .HasColumnType("int");

                    b.Property<string>("CardinalDirection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Perimeter")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SingleArea")
                        .HasColumnType("float");

                    b.Property<double>("U")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BuildingParametersId");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Library.Window", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BuildingParametersId")
                        .HasColumnType("int");

                    b.Property<string>("CardinalDirection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Perimeter")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SingleArea")
                        .HasColumnType("float");

                    b.Property<double>("U")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BuildingParametersId");

                    b.ToTable("Windows");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.BuildingInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("BuildingParametersId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InvestorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BuildingParametersId");

                    b.HasIndex("InvestorId");

                    b.ToTable("BuildingInformation");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.BuildingObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuildingInformationId")
                        .HasColumnType("int");

                    b.Property<int>("BuildingParametersId")
                        .HasColumnType("int");

                    b.Property<int>("DivisionalStructureId")
                        .HasColumnType("int");

                    b.Property<int>("FloorOnTheGroundId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingInformationId");

                    b.HasIndex("DivisionalStructureId");

                    b.HasIndex("FloorOnTheGroundId");

                    b.ToTable("BuildingObjects");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.BuildingParameters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("AtticUsableArea")
                        .HasColumnType("float");

                    b.Property<double>("BalconyLength")
                        .HasColumnType("float");

                    b.Property<double>("BuildingArea")
                        .HasColumnType("float");

                    b.Property<double>("BuildingLengthE")
                        .HasColumnType("float");

                    b.Property<double>("BuildingLengthN")
                        .HasColumnType("float");

                    b.Property<double>("BuildingLengthS")
                        .HasColumnType("float");

                    b.Property<double>("BuildingLengthW")
                        .HasColumnType("float");

                    b.Property<double>("CellarHeight")
                        .HasColumnType("float");

                    b.Property<double>("HeatAtticArea")
                        .HasColumnType("float");

                    b.Property<double>("PerimeterOfTheBuilding")
                        .HasColumnType("float");

                    b.Property<int>("SolutionId")
                        .HasColumnType("int");

                    b.Property<double>("StaircaseSurface")
                        .HasColumnType("float");

                    b.Property<double>("StaircaseWidth")
                        .HasColumnType("float");

                    b.Property<double>("StoreyHeightGross")
                        .HasColumnType("float");

                    b.Property<double>("StoreyHeightNet")
                        .HasColumnType("float");

                    b.Property<int>("StoreyQuantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalDoorAreaE")
                        .HasColumnType("float");

                    b.Property<double>("TotalDoorAreaN")
                        .HasColumnType("float");

                    b.Property<double>("TotalDoorAreaS")
                        .HasColumnType("float");

                    b.Property<double>("TotalDoorAreaW")
                        .HasColumnType("float");

                    b.Property<double>("TotalWindowAreaE")
                        .HasColumnType("float");

                    b.Property<double>("TotalWindowAreaN")
                        .HasColumnType("float");

                    b.Property<double>("TotalWindowAreaS")
                        .HasColumnType("float");

                    b.Property<double>("TotalWindowAreaW")
                        .HasColumnType("float");

                    b.Property<double>("UnheatedAtticArea")
                        .HasColumnType("float");

                    b.Property<double>("UsableAreaOfTheBuilding")
                        .HasColumnType("float");

                    b.Property<double>("UsableAreaOfTheStairCase")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BuildingParameters");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.DivisionalStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DivisionalThickness")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RSum")
                        .HasColumnType("float");

                    b.Property<double>("Rse")
                        .HasColumnType("float");

                    b.Property<double>("Rsi")
                        .HasColumnType("float");

                    b.Property<double>("U")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DivisionalStructures");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.FloorOnTheGround", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Ag")
                        .HasColumnType("float");

                    b.Property<double>("B")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroundMaterial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("P")
                        .HasColumnType("float");

                    b.Property<double>("Rf")
                        .HasColumnType("float");

                    b.Property<double>("Ugr")
                        .HasColumnType("float");

                    b.Property<double>("df")
                        .HasColumnType("float");

                    b.Property<double>("dt")
                        .HasColumnType("float");

                    b.Property<double>("w")
                        .HasColumnType("float");

                    b.Property<double>("λf")
                        .HasColumnType("float");

                    b.Property<double>("λgr")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("FloorOnTheGround");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.Investor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Investors");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.ProjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectModels");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.Solution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuildingObjectId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpireTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ResetPasswordExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Library.BuildingMaterialDivisionalStructure", b =>
                {
                    b.HasOne("BuildingEnergyCalculator.Entities.Library.BuildingMaterial", "BuildingMaterial")
                        .WithMany()
                        .HasForeignKey("BuildingMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingEnergyCalculator.Entities.Project.DivisionalStructure", "DivisionalStructure")
                        .WithMany()
                        .HasForeignKey("DivisionalStructureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingMaterial");

                    b.Navigation("DivisionalStructure");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Library.Door", b =>
                {
                    b.HasOne("BuildingEnergyCalculator.Entities.Project.BuildingParameters", null)
                        .WithMany("Doors")
                        .HasForeignKey("BuildingParametersId");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Library.Window", b =>
                {
                    b.HasOne("BuildingEnergyCalculator.Entities.Project.BuildingParameters", null)
                        .WithMany("Windows")
                        .HasForeignKey("BuildingParametersId");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.BuildingInformation", b =>
                {
                    b.HasOne("BuildingEnergyCalculator.Entities.Project.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingEnergyCalculator.Entities.Project.BuildingParameters", "BuildingParameters")
                        .WithMany()
                        .HasForeignKey("BuildingParametersId");

                    b.HasOne("BuildingEnergyCalculator.Entities.Project.Investor", "Investor")
                        .WithMany()
                        .HasForeignKey("InvestorId");

                    b.Navigation("Address");

                    b.Navigation("BuildingParameters");

                    b.Navigation("Investor");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.BuildingObject", b =>
                {
                    b.HasOne("BuildingEnergyCalculator.Entities.Project.BuildingInformation", "BuildingInformation")
                        .WithMany()
                        .HasForeignKey("BuildingInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingEnergyCalculator.Entities.Project.DivisionalStructure", "DivisionalStructure")
                        .WithMany()
                        .HasForeignKey("DivisionalStructureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingEnergyCalculator.Entities.Project.FloorOnTheGround", "FloorOnTheGround")
                        .WithMany()
                        .HasForeignKey("FloorOnTheGroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingInformation");

                    b.Navigation("DivisionalStructure");

                    b.Navigation("FloorOnTheGround");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.Investor", b =>
                {
                    b.HasOne("BuildingEnergyCalculator.Entities.Project.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.User", b =>
                {
                    b.HasOne("BuildingEnergyCalculator.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.Project.BuildingParameters", b =>
                {
                    b.Navigation("Doors");

                    b.Navigation("Windows");
                });
#pragma warning restore 612, 618
        }
    }
}
