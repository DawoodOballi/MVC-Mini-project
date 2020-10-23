using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcOvertime.Migrations
{
    public partial class EndTime_Date_Day : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Overtime");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Overtime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Overtime");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Overtime",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
