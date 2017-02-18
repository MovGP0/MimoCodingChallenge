using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mimo.Business.Users
{
    public sealed class CourseInfo
    {
        public CourseInfo(string courseName, DateTime started, DateTime completed, IEnumerable<ChapterInfo> chapterInfos)
        {
            CourseName = courseName;
            Started = started;
            Completed = completed;
            ChapterInfos = chapterInfos.ToImmutableArray();
        }

        public string CourseName { get; }
        public DateTime Started { get; }
        public DateTime Completed { get; }
        public IEnumerable<ChapterInfo> ChapterInfos { get; }
    }
}