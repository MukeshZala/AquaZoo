using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaZooAPI.Migrations
{
    public partial class ColumnAdjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationProgramEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_LocationProgramEntities_AquaZooEntities_AquaZooId",
                        column: x => x.AquaZooId,
                        principalTable: "AquaZooEntities",
                        principalColumn: "AquaZooId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationProgramEntities_AquaZooId",
                table: "LocationProgramEntities",
                column: "AquaZooId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationProgramEntities");
        }
    }
}
