using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netflixAPI.Data.Migrations
{
    public partial class UserProgramTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPrograms",
                columns: table => new
                {
                    UserPrgID = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PrgID = table.Column<Guid>(nullable: false),
                    LastWatchedTime = table.Column<DateTime>(nullable: false),
                    WatchedTime = table.Column<double>(nullable: false),
                    LastEpisode = table.Column<int>(nullable: false),
                    UserGrade = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrograms", x => x.UserPrgID);
                    table.ForeignKey(
                        name: "FK_UserPrograms_Programs_PrgID",
                        column: x => x.PrgID,
                        principalTable: "Programs",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrograms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPrograms_PrgID",
                table: "UserPrograms",
                column: "PrgID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrograms_UserId",
                table: "UserPrograms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPrograms");
        }
    }
}
