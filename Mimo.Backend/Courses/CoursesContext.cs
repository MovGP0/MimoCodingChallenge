using Microsoft.EntityFrameworkCore;

namespace Mimo.Backend.Courses
{
    public class CoursesContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}