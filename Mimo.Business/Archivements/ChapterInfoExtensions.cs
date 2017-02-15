using System;
using System.Collections.Generic;
using System.Linq;
using Mimo.Business.Users;

namespace Mimo.Business.Archivements
{
    public static class ChapterInfoExtensions
    {
        public static int GetNumberOfCompletedChapters(this IEnumerable<ChapterInfo> chapters)
        {
            return chapters.Count(c => c.Completed != default(DateTime));
        }
    }
}