using System;

namespace Mimo.Business.Users
{
    public sealed class LessonInfo
    {
        public LessonInfo(string lessonName, DateTime started, DateTime completed)
        {
            LessonName = lessonName;
            Started = started;
            Completed = completed;
        }

        public string LessonName { get; }
        public DateTime Started { get; }
        public DateTime Completed { get; }
    }
}