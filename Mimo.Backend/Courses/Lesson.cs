using System.ComponentModel.DataAnnotations;

namespace Mimo.Backend.Courses
{
    public class Lesson
    {
        [Key]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}