using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mimo.Backend.Users
{
    [Table("LessonInfos")]
    public class LessonInfo
    {
        [Key]
        public string LessonName { get; set; }
        public DateTime Started { get; set; }
        public DateTime Completed { get; set; }
    }
}