using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mimo.Backend.Users
{
    [Table("CourseInfos")]
    public class CourseInfo
    {
        [Key]
        public string CourseName { get; set; }
        public DateTime Started { get; set; }
        public DateTime Completed { get; set; }

        public IEnumerable<ChapterInfo> ChapterInfos { get; set; }
    }
}