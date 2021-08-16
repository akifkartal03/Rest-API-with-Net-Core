using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netflixAPI.Data.Migrations
{
    public partial class ProgramTypeTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramTypes",
                columns: table => new
                {
                    PrgTypeId = table.Column<Guid>(nullable: false),
                    PrgId = table.Column<Guid>(nullable: false),
                    TypeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTypes", x => x.PrgTypeId);
                    table.ForeignKey(
                        name: "FK_ProgramTypes_Programs_PrgId",
                        column: x => x.PrgId,
                        principalTable: "Programs",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramTypes_Types_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Types",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTypes_PrgId",
                table: "ProgramTypes",
                column: "PrgId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTypes_TypeID",
                table: "ProgramTypes",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramTypes");
        }
    }
}
