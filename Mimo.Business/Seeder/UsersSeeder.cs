using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mimo.Backend.Users;

namespace Mimo.Business.Seeder
{
    public static class UsersSeeder
    {
        public static async Task SeedUsersAsync(this UsersContext context, CancellationToken cancellationToken)
        {
            if (!context.Users.Any())
            {

            }

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}