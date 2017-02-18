using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mimo.Backend.Courses;
using Mimo.Business.Courses;
using Xunit;
using Course = Mimo.Business.Courses.Course;

namespace Mimo.Business.Tests
{
    public class CoursesRepositoryTests : AppSettingsTest
    {
        ~CoursesRepositoryTests()
        {
            try
            {
                var connectionString = Configuration["CoursesConnectionString"];
                using (var context = new CoursesContext(connectionString))
                {
                    var allCourses = context.Courses;
                    context.Courses.RemoveRange(allCourses);
                    context.SaveChangesAsync().Wait();
                }
            }
            catch
            {
            }
        }

        [Fact]
        public async Task CreateCourses()
        {
            var courses = new[]
            {
                new Course {Name = "Swift"},
                new Course {Name = "Javascript"},
                new Course {Name = "C#"}
            };

            var connectionString = Configuration["CoursesConnectionString"];
            using (var context = new CoursesContext(connectionString))
            {
                var repositoy = new CoursesRepository(context);
                await repositoy.AddRangeAsync(courses, CancellationToken.None);
                var coursesFromDatabase = context.Courses.ToArray();

                Assert.Equal(coursesFromDatabase.Length, 3);
            }
        }
    }
}
