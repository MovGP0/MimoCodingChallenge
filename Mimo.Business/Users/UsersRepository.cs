using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mimo.Backend.Users;

namespace Mimo.Business.Users
{
    public sealed class UsersRepository : IUsersRepository
    {
        private UsersContext Context { get; }

        public UsersRepository(UsersContext context)
        {
            Context = context;
        }

        public async Task<User> GetAsync(string userName, CancellationToken cancellationToken)
        {
            var user = await Context.Users
                .Include(u => u.CourseInfos)
                .ThenInclude(ci => ci.ChapterInfos)
                .ThenInclude(ci => ci.LessonInfos)
                .SingleAsync(u => u.Name == userName, cancellationToken);
            return UserMapper.ToBusiness(user);
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await Context.Users.AddAsync(UserMapper.ToBackend(user), cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddLessonAsync(string userName, string courseName, string chapterName, LessonInfo lessonInfo, CancellationToken cancellationToken)
        {
            var user = await Context.Users
                .Include(u => u.CourseInfos)
                .ThenInclude(ci => ci.ChapterInfos)
                .ThenInclude(ci => ci.LessonInfos)
                .SingleAsync(u => u.Name == userName, cancellationToken);

            var chapter = user
                .CourseInfos.Single(u => u.CourseName == courseName)
                .ChapterInfos.Single(u => u.ChapterName == chapterName);

            chapter.LessonInfos = chapter.LessonInfos.Append(UserMapper.ToBackend(lessonInfo));

            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}