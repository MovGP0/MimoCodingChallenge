using System.Collections.Generic;

namespace Mimo.Business.Courses
{
    public class Course
    {
        public string Name { get; set; }
        public IList<Chapter> Chapters { get; set; }
    }
}
