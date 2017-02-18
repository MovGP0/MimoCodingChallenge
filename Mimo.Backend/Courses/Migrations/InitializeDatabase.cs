using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimo.Backend.Courses.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chapters", 
                columns: table => new
                {
                    
                }, 
                constraints: table =>
                {
                    
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {

                },
                constraints: table =>
                {

                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {

                },
                constraints: table =>
                {

                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Chapters");
            migrationBuilder.DropTable("Courses");
            migrationBuilder.DropTable("Lessons");
        }
    }
}
