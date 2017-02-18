using Xunit;

namespace Mimo.Backend.Tests
{
    public sealed class AppSettingsTests : AppSettingsTest
    {
        [Fact]
        public void CanReadUsersConnectionString()
        {
            var connectionString = Configuration["UsersConnectionString"];
            Assert.Equal("Filename=./Users.db", connectionString);
        }

        [Fact]
        public void CanReadCoursesConnectionString()
        {
            var connectionString = Configuration["CoursesConnectionString"];
            Assert.Equal("Filename=./Courses.db", connectionString);
        }
    }
}
