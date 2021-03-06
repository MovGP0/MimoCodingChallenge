using System.Linq;
using Mimo.Business.Users;

namespace Mimo.Business.Archivements
{
    public class CompletedChaptersArchivement : Archivement
    {
        public override string Name => $"Complete {NumberOfChaptersRequired} chapters";
        public override bool IsApplyableToUser(User user)
        {
            var nuberOfCompletedChapters = user.CourseInfos.SelectMany(ci => ci.ChapterInfos).GetNumberOfCompletedChapters();
            return nuberOfCompletedChapters >= NumberOfChaptersRequired;
        }

        public int NumberOfChaptersRequired { set; private get; }
    }
}