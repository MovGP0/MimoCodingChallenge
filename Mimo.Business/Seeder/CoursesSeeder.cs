using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mimo.Backend.Courses;

namespace Mimo.Business.Seeder
{
    public static class CoursesSeeder
    {
        public static async Task SeedCoursesAsync(this IServiceScope serviceScope, CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetService<CoursesContext>();

            if (!context.Courses.Any())
            {
                var courses = new[]
                {
                        new Course { Name = "Swift" },
                        new Course { Name = "JavaScript" },
                        new Course { Name = "C#" }
                    };
                await context.Courses.AddRangeAsync(courses);
            }

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}