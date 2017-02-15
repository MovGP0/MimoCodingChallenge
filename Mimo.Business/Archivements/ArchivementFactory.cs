using System.Collections.Generic;

namespace Mimo.Business.Archivements
{
    public static class ArchivementFactory
    {
        public static IEnumerable<Archivement> Create()
        {
            yield return new CompletedLessonsArchivement { NumberOfLessonsRequired = 5 };
            yield return new CompletedLessonsArchivement { NumberOfLessonsRequired = 25 };
            yield return new CompletedLessonsArchivement { NumberOfLessonsRequired = 50 };

            yield return new CompletedChaptersArchivement { NumberOfChaptersRequired = 1 };
            yield return new CompletedChaptersArchivement { NumberOfChaptersRequired = 5 };

            yield return new CompletedCourseArchivement { CourseName = "Swift" };
            yield return new CompletedCourseArchivement { CourseName = "JavaScript" };
            yield return new CompletedCourseArchivement { CourseName = "C#" };
        }
    }
}