using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaZooAPI.Migrations
{
    public partial class addLocationProgramToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationProgramEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AquaZooId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationProgramEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationProgramEntities_AquaZooEntities_Id",
                        column: x => x.Id,
                        principalTable: "AquaZooEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationProgramEntities");
        }
    }
}
