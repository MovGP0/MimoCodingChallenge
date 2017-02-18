using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mimo.Business.Users
{
    public sealed class ChapterInfo
    {
        public ChapterInfo(string chapterName, DateTime started, DateTime completed, IEnumerable<LessonInfo> lessonInfos)
        {
            ChapterName = chapterName;
            Started = started;
            Completed = completed;
            LessonInfos = lessonInfos.ToImmutableArray();
        }

        public string ChapterName { get; }
        public DateTime Started { get; }
        public DateTime Completed { get; }
        public IEnumerable<LessonInfo> LessonInfos { get; }
    }
}