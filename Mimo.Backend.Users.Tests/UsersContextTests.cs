using System.Threading.Tasks;
using Xunit;

namespace Mimo.Backend.Users.Tests
{
    public sealed class UsersContextTests : AppSettingsTest
    {
        [Fact]
        public async Task CreateUsersContextDatabase()
        {
            var connectionString = Configuration["UsersConnectionString"];
            using (var context = new UsersContext(connectionString))
            {
                var success = await context.Database.EnsureCreatedAsync();
                Assert.True(success);
            }
        }
    }
}