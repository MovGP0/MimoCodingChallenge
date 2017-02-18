using System.Threading.Tasks;
using Xunit;

namespace Mimo.Backend.Courses.Tests
{
    public sealed class CoursesContextTests : AppSettingsTest
    { 
        [Fact]
        public async Task CreateCoursesContextDatabase()
        {
            var connectionString = Configuration["CoursesConnectionString"];
            using (var context = new CoursesContext(connectionString))
            {
                var success = await context.Database.EnsureCreatedAsync();
                Assert.True(success);
            }
        }
    }
}