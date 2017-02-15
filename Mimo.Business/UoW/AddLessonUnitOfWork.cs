using System;
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

        public async Task ExecuteAsync(string userName, LessonInfo lessonInfo, CancellationToken cancellationToken)
        {
            var user = await UsersRepository.GetAsync(userName, cancellationToken);

            RemoveProviouslyStartedLesson(user, lessonInfo);
            AddLesson(user, lessonInfo);
        }

        private static void AddLesson(User user, LessonInfo lessonInfo)
        {
            user.LessonInfos.Add(lessonInfo);
        }

        private static void RemoveProviouslyStartedLesson(User user, LessonInfo lessonInfo)
        {
            var nonCompletedLesson = user.LessonInfos
                .Where(li => li.Completed == default(DateTime))
                .SingleOrDefault(li => li.LessonName == lessonInfo.LessonName);

            if (nonCompletedLesson != default(LessonInfo))
            {
                user.LessonInfos.Remove(nonCompletedLesson);
            }
        }
    }
}