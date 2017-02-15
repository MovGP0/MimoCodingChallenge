using System;
using System.Collections.Generic;
using System.Linq;
using Mimo.Business.Users;

namespace Mimo.Business.Archivements
{
    public static class CourseInfoExtensions
    {
        public static bool HasCompleted(this IEnumerable<CourseInfo> courses, string courseName)
        {
            return courses.Where(c => c.Completed != default(DateTime)).Any(c => c.CourseName == courseName);
        }
    }
}