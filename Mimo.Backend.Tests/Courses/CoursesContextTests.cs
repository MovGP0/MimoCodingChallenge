using System.Threading.Tasks;
using Mimo.Backend.Courses;
using Xunit;

namespace Mimo.Backend.Tests.Courses
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