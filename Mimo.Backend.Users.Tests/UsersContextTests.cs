using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Mimo.Backend.Users.Tests
{
    public sealed class UsersContextTests : AppSettingsTest
    {
        public UsersContextTests()
        {
            using (var cts = new CancellationTokenSource(1000))
            {
                SetupAsync(cts.Token).Wait();
            }
        }

        private async Task SetupAsync(CancellationToken cancellationToken)
        {
            var connectionString = Configuration["CoursesConnectionString"];
            using (var context = new UsersContext(connectionString))
            {
                await context.Database.EnsureCreatedAsync(cancellationToken);
                context.Users.RemoveRange(context.Users);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        [Fact]
        public async Task CreateUsersContextDatabase()
        {
            using (var cts = new CancellationTokenSource(1000))
            {
                var connectionString = Configuration["UsersConnectionString"];
                using (var context = new UsersContext(connectionString))
                {
                    var user = new User
                    {
                        Name = "Fred"
                    };

                    await context.Users.AddAsync(user, cts.Token);

                    await context.SaveChangesAsync(cts.Token);
                    var numberOfUsers = await context.Users.CountAsync(cts.Token);

                    Assert.Equal(1, numberOfUsers);
                }
            }
        }

        ~UsersContextTests()
        {
            using (var cts = new CancellationTokenSource(1000))
            {
                TearDownAsync(cts.Token).Wait();
            }
        }

        private async Task TearDownAsync(CancellationToken cancellationToken)
        {
            var connectionString = Configuration["CoursesConnectionString"];
            using (var context = new UsersContext(connectionString))
            {
                await context.Database.EnsureDeletedAsync(cancellationToken);
            }
        }
    }
}