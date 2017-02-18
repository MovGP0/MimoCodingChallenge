using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimo.Backend.Courses.Migrations
{
    [DbContext(typeof(CoursesContext))]
    [Migration("20170218000001_Seeding")]
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = new CoursesContext())
            {
                context.Courses.AddRange(new Course { Name = "Swift" });
                context.Courses.AddRange(new Course { Name = "JavaScript" });
                context.Courses.AddRange(new Course { Name = "C#" });
                context.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var context = new CoursesContext())
            {
                context.RemoveRange(context.Courses);
                context.SaveChanges();
            }
        }
    }
}
