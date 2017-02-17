using Microsoft.EntityFrameworkCore;

namespace Mimo.Backend.Users
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Users.db");
        }
    }
}