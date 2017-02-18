using System.Linq;
using Mimo.Business.Users;

namespace Mimo.Business.Archivements
{
    public class CompletedLessonsArchivement : Archivement
    {
        public override string Name => $"Complete {NumberOfLessonsRequired} lessons";
        public override bool IsApplyableToUser(User user)
        {
            var numberOfLessons = user.CourseInfos
                .SelectMany(ci => ci.ChapterInfos)
                .SelectMany(ci => ci.LessonInfos)
                .GetNumberOfCompletedLessons();

            return numberOfLessons >= NumberOfLessonsRequired;
        }

        public int NumberOfLessonsRequired { set; private get; }
    }
}