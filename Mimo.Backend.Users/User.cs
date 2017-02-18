using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mimo.Backend.Users
{
    [Table("Users")]
    public class User
    {
        [Key]
        public string Name { get; set; }

        public IEnumerable<CourseInfo> CourseInfos { get; set; }
    }
}