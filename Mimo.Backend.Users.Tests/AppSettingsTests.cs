using Xunit;

namespace Mimo.Backend.Users.Tests
{
    public sealed class AppSettingsTests : AppSettingsTest
    {
        [Fact]
        public void CanReadUsersConnectionString()
        {
            var connectionString = Configuration["UsersConnectionString"];
            Assert.Equal("Filename=./Users.db", connectionString);
        }
    }
}
