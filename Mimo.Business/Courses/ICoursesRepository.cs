using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mimo.Business.Courses
{
    public interface ICoursesRepository
    {
        Task AddRangeAsync(IEnumerable<Course> courses, CancellationToken cancellationToken);
        Task AddAsync(Course course, CancellationToken cancellationToken);
        Task<IEnumerable<Course>> GetAll(CancellationToken cancellationToken);
    }
}