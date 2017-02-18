using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mimo.Backend.Users
{
    [Table("ChapterInfos")]
    public class ChapterInfo
    {
        [Key]
        public string ChapterName { get; set; }
        public DateTime Started { get; set; }
        public DateTime Completed { get; set; }

        public IEnumerable<LessonInfo> LessonInfos { get; set; }
    }
}