using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Mimo.Backend.Courses.Tests
{
    public sealed class CoursesContextTests : AppSettingsTest
    {
        public CoursesContextTests()
        {
            using (var cts = new CancellationTokenSource(1000))
            {
                SetupAsync(cts.Token).Wait();
            }
        }

        private async Task SetupAsync(CancellationToken cancellationToken)
        {
            var connectionString = Configuration["CoursesConnectionString"];
            using (var context = new CoursesContext(connectionString))
            {
                await context.Database.EnsureCreatedAsync(cancellationToken);
                context.Courses.RemoveRange(context.Courses);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        [Fact]
        public async Task CreateCoursesContextDatabase()
        {
            var cancellationToken = CancellationToken.None;
            var connectionString = Configuration["CoursesConnectionString"];
            using (var context = new CoursesContext(connectionString))
            {
                await context.Courses.AddAsync(new Course {Name = "Foo"}, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                var numberOfCourses = await context.Courses.CountAsync(cancellationToken);

                Assert.Equal(1, numberOfCourses);
            }
        }

        ~CoursesContextTests()
        {
            using (var cts = new CancellationTokenSource(1000))
            {
                TearDownAsync(cts.Token).Wait();
            }
        }

        private async Task TearDownAsync(CancellationToken cancellationToken)
        {
            var connectionString = Configuration["CoursesConnectionString"];
            using (var context = new CoursesContext(connectionString))
            {
                await context.Database.EnsureDeletedAsync(cancellationToken);
            }
        }
    }
}