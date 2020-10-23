using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcOvertime.Migrations
{
    public partial class DtStartTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtStartTime",
                table: "Overtime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Overtime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Overtime",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "DtStartTime",
                table: "Overtime",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
