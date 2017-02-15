using Mimo.Business.Users;

namespace Mimo.Business.Archivements
{
    public class CompletedCourseArchivement : Archivement
    {
        public override string Name => $"Complete the {CourseName} course";
        public override bool IsApplyableToUser(User user)
        {
            return user.CourseInfos.HasCompleted(CourseName);
        }

        public string CourseName { set; private get; }
    }
}