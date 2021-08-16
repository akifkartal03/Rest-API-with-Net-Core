using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netflixAPI.Data.Migrations
{
    public partial class programTableRemove2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberofEpisode = table.Column<int>(type: "int", nullable: false),
                    ProgramLength = table.Column<float>(type: "real", nullable: false),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramID);
                });
        }
    }
}
