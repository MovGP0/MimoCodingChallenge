using System.Collections.Generic;

namespace Mimo.Business.Courses
{
    public class Chapter
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public IList<Lesson> Lessons { get; set; }
    }
}