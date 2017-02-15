using System;
using System.Collections.Generic;
using System.Linq;
using Mimo.Business.Users;

namespace Mimo.Business.Archivements
{
    public static class LessonInfoExtensions
    {
        public static int GetNumberOfCompletedLessons(this IEnumerable<LessonInfo> lessons)
        {
            return lessons.Count(l => l.Completed != default(DateTime));
        }
    }
}