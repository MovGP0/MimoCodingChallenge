using Microsoft.EntityFrameworkCore;

namespace Mimo.Backend.Courses
{
    public class CoursesContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Courses.db");
        }
    }
}