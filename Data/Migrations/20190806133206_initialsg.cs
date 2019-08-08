using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillHub.Data.Migrations
{
    public partial class initialsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Courses");
        }
    }
}
