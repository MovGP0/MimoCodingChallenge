using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mimo.Backend.Courses;
using Mimo.Business.Courses;
using Xunit;
using Course = Mimo.Business.Courses.Course;

namespace Mimo.Business.Tests
{
    public class CoursesRepositoryTests
    {
        ~CoursesRepositoryTests()
        {
            using (var context = new CoursesContext())
            {
                var allCourses = context.Courses;
                context.Courses.RemoveRange(allCourses);
                context.SaveChangesAsync().Wait();
            }
        }

        [Fact]
        public async Task CreateCourses()
        {
            var repositoy = new CoursesRepository();

            var courses = new[]
                {
                    new Course {Name = "Swift"},
                    new Course {Name = "Javascript"},
                    new Course {Name = "C#"}
                };

            await repositoy.AddRangeAsync(courses, CancellationToken.None);

            using (var context = new CoursesContext())
            {
                var coursesFromDatabase = context.Courses.ToArray();
                
                Assert.Equal(coursesFromDatabase.Length, 3);
            }
        }
    }
}
