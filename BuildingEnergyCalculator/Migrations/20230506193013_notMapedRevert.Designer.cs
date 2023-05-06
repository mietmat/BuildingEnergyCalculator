﻿// <auto-generated />
using System;
using BuildingEnergyCalculator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuildingEnergyCalculator.Migrations
{
    [DbContext(typeof(EnergyCalculatorDbContext))]
    [Migration("20230506193013_notMapedRevert")]
    partial class notMapedRevert
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.BuildingMaterial", b =>
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

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.BuildingMaterialDivisionalStructure", b =>
                {
                    b.Property<int>("DivisionalStructureId")
                        .HasColumnType("int");

                    b.Property<int>("BuildingMaterialId")
                        .HasColumnType("int");

                    b.HasKey("DivisionalStructureId", "BuildingMaterialId");

                    b.HasIndex("BuildingMaterialId");

                    b.ToTable("BuildingMaterialDivisionalStructures");
                });

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.DivisionalStructure", b =>
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

            modelBuilder.Entity("BuildingEnergyCalculator.Entities.BuildingMaterialDivisionalStructure", b =>
                {
                    b.HasOne("BuildingEnergyCalculator.Entities.BuildingMaterial", "BuildingMaterial")
                        .WithMany()
                        .HasForeignKey("BuildingMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingEnergyCalculator.Entities.DivisionalStructure", "DivisionalStructure")
                        .WithMany()
                        .HasForeignKey("DivisionalStructureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingMaterial");

                    b.Navigation("DivisionalStructure");
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
#pragma warning restore 612, 618
        }
    }
}
