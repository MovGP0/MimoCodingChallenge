using Microsoft.EntityFrameworkCore;

namespace Mimo.Backend.Users
{
    public class UsersContext : DbContext
    {
        private string ConnectionString { get; }

        public UsersContext(string connectionString = null)
        {
            ConnectionString = connectionString;
        }
        
        public UsersContext(DbContextOptions<UsersContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString ?? "Filename=./Users.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}