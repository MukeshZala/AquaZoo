using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaZooAPI.Migrations
{
    public partial class RemoveLocationProgramToDBAndRenameAquaZooId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationProgramEntities");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AquaZooEntities",
                newName: "AquaZooId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AquaZooId",
                table: "AquaZooEntities",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "LocationProgramEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AgeGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AquaZooId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
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
    }
}
