using Xunit;

namespace Mimo.Backend.Courses.Tests
{
    public sealed class AppSettingsTests : AppSettingsTest
    {
        [Fact]
        public void CanReadCoursesConnectionString()
        {
            var connectionString = Configuration["CoursesConnectionString"];
            Assert.Equal("Filename=./Courses.db", connectionString);
        }
    }
}
