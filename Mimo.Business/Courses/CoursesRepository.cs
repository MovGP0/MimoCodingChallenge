using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mimo.Backend.Courses;

namespace Mimo.Business.Courses
{
    public sealed class CoursesRepository : ICoursesRepository
    {
        private CoursesContext Context { get; }

        public CoursesRepository(CoursesContext context)
        {
            Context = context;
        }

        public async Task AddRangeAsync(IEnumerable<Course> courses, CancellationToken cancellationToken)
        {
            await Context.Courses.AddRangeAsync(CoursesMapper.ToBackend(courses), cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddAsync(Course course, CancellationToken cancellationToken)
        {
            await Context.Courses.AddAsync(CoursesMapper.ToBackend(course), cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Course>> GetAll(CancellationToken cancellationToken)
        {
            var courses = await Context.Courses.ToListAsync(cancellationToken);
            return CoursesMapper.ToBusiness(courses);
        }
    }
}
