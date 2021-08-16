using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netflixAPI.Data.Migrations
{
    public partial class IdentityDBUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UserBirthday",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserBirthday",
                table: "AspNetUsers");
        }
    }
}
