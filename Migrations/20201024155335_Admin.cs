using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcOvertime.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AdminId",
                table: "Employee",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Admin_AdminId",
                table: "Employee",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Admin_AdminId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AdminId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Employee");
        }
    }
}
