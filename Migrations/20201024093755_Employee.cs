using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcOvertime.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Overtime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Overtime_EmployeeId",
                table: "Overtime",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Overtime_Employee_EmployeeId",
                table: "Overtime",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Overtime_Employee_EmployeeId",
                table: "Overtime");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Overtime_EmployeeId",
                table: "Overtime");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Overtime");
        }
    }
}
