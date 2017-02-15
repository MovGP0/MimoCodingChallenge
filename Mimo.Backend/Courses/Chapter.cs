using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mimo.Backend.Courses
{
    public class Chapter
    {
        [Key]
        public string Name { get; set; }
        public int Order { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
    }
}