using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mimo.Business.Users;

namespace Mimo.Business.UoW
{
    public sealed class AddLessonUnitOfWork
    {
        public AddLessonUnitOfWork(IUsersRepository usersRepository)
        {
            UsersRepository = usersRepository;
        }

        private IUsersRepository UsersRepository { get; }

        public async Task ExecuteAsync(string userName, string courseName, string chapterName, LessonInfo lessonInfo, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrWhiteSpace(courseName)) throw new ArgumentNullException(nameof(courseName));
            if (string.IsNullOrWhiteSpace(chapterName)) throw new ArgumentNullException(nameof(chapterName));
            EnsureLessonInfo(lessonInfo);

            var user = await UsersRepository.GetAsync(userName, cancellationToken);

            var courseInfo = user.CourseInfos.SingleOrDefault(ci => ci.CourseName == courseName);
            if (courseInfo == null) throw new InvalidOperationException($"User has not started course '{courseName}'.");

            var chapterInfo = courseInfo.ChapterInfos.SingleOrDefault(ci => ci.ChapterName == chapterName);
            if (chapterInfo == null) throw new InvalidOperationException($"User has not started chapter '{chapterName}'.");

            await UsersRepository.AddLessonAsync(userName, courseName, chapterName, lessonInfo, cancellationToken);
        }

        [DebuggerStepThrough]
        private static void EnsureLessonInfo(LessonInfo lessonInfo)
        {
            if (lessonInfo == null)
            {
                throw new ArgumentNullException(nameof(lessonInfo));
            }

            if (string.IsNullOrWhiteSpace(lessonInfo.LessonName))
            {
                throw new ArgumentException("LessonName is not set", nameof(lessonInfo));
            }

            if (lessonInfo.Started == default(DateTime))
            {
                throw new ArgumentException("Started is not set", nameof(lessonInfo));
            }

            if (lessonInfo.Completed == default(DateTime))
            {
                throw new ArgumentException("Completed is not set", nameof(lessonInfo));
            }
        }
    }
}