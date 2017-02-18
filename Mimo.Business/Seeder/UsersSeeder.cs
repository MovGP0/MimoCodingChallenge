using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mimo.Backend.Users;

namespace Mimo.Business.Seeder
{
    public static class UsersSeeder
    {
        public static async Task SeedUsersAsync(this IServiceScope serviceScope, CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetService<UsersContext>();

            if (!context.Users.Any())
            {

            }

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}