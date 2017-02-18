using Microsoft.EntityFrameworkCore;

namespace Mimo.Backend.Courses
{
    public class CoursesContext : DbContext
    {
        private string ConnectionString { get; }

        public CoursesContext(string connectionString = null)
        {
            ConnectionString = connectionString;
        }

        public CoursesContext(DbContextOptions<CoursesContext> options) 
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString ?? "Filename=./Courses.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}