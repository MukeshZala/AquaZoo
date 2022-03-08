using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaZooAPI.Migrations
{
    public partial class AquaZooDateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AquaZooEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Started",
                table: "AquaZooEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "AquaZooEntities");

            migrationBuilder.DropColumn(
                name: "Started",
                table: "AquaZooEntities");
        }
    }
}
