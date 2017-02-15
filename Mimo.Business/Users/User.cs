using System.Collections.Generic;

namespace Mimo.Business.Users
{
    public class User
    {
        public string Name { get; set; }
        public IList<CourseInfo> CourseInfos { get; set; }
        public IList<ChapterInfo> ChapterInfos { get; set; }
        public IList<LessonInfo> LessonInfos { get; set; }
    }
}