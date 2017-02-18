using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mimo.Backend.Courses
{
    public class Course
    {
        [Key]
        public string Name { get; set; }

        public IEnumerable<Chapter> Chapters { get; set; }
    }
}
