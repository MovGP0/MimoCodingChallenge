using Microsoft.EntityFrameworkCore;

namespace Mimo.Backend.Courses
{
    public class CoursesContext : DbContext
    {
        private string ConnectionString { get; }

        public CoursesContext()
        {
        }

        public CoursesContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString ?? "Filename=./Courses.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}