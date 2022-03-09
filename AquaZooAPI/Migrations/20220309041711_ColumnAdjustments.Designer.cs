﻿// <auto-generated />
using System;
using AquaZooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AquaZooAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220309041711_ColumnAdjustments")]
    partial class ColumnAdjustments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AquaZooAPI.Models.AquaZooEntity", b =>
                {
                    b.Property<int>("AquaZooId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AquaZooId"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Started")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AquaZooId");

                    b.ToTable("AquaZooEntities");
                });

            modelBuilder.Entity("AquaZooAPI.Models.LocationProgramEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AgeGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AquaZooId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AquaZooId");

                    b.ToTable("LocationProgramEntities");
                });

            modelBuilder.Entity("AquaZooAPI.Models.LocationProgramEntity", b =>
                {
                    b.HasOne("AquaZooAPI.Models.AquaZooEntity", "AquaZooEntity")
                        .WithMany()
                        .HasForeignKey("AquaZooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AquaZooEntity");
                });
#pragma warning restore 612, 618
        }
    }
}