using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApiDemo.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name1",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name1",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
