using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mimo.Backend.Courses;

namespace Mimo.Business.Courses
{
    public sealed class CoursesRepository : ICoursesRepository
    {
        private static CoursesContext GetContext()
        {
            return new CoursesContext();
        }

        public async Task AddRangeAsync(IEnumerable<Course> courses, CancellationToken cancellationToken)
        {
            using (var context = GetContext())
            {
                await context.Courses.AddRangeAsync(CoursesMapper.ToBackend(courses), cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task AddAsync(Course course, CancellationToken cancellationToken)
        {
            using (var context = GetContext())
            {
                await context.Courses.AddAsync(CoursesMapper.ToBackend(course), cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<Course>> GetAll(CancellationToken cancellationToken)
        {
            using (var context = GetContext())
            {
                var courses = await context.Courses.ToListAsync(cancellationToken);
                return CoursesMapper.ToBusiness(courses);
            }
        }
    }
}
