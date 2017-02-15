using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mimo.Backend.Users
{
    public class User
    {
        [Key]
        public string Name { get; set; }

        public IEnumerable<CourseInfo> CourseInfos { get; set; }
        public IEnumerable<ChapterInfo> ChapterInfos { get; set; }
        public IEnumerable<LessonInfo> LessonInfos { get; set; }
    }
}