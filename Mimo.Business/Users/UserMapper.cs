using System;
using System.Linq;

namespace Mimo.Business.Users
{
    public static class UserMapper
    {
        public static User ToBusiness(Backend.Users.User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return new User(
                user.Name, 
                user.CourseInfos.Select(ToBusiness));
        }

        public static LessonInfo ToBusiness(Backend.Users.LessonInfo lessonInfo)
        {
            if (lessonInfo == null) throw new ArgumentNullException(nameof(lessonInfo));

            return new LessonInfo
            (
                lessonInfo.LessonName,
                lessonInfo.Started,
                lessonInfo.Completed
            );
        }

        public static ChapterInfo ToBusiness(Backend.Users.ChapterInfo chapterInfo)
        {
            if (chapterInfo == null) throw new ArgumentNullException(nameof(chapterInfo));

            return new ChapterInfo
            (
                chapterInfo.ChapterName, 
                chapterInfo.Started, 
                chapterInfo.Completed,
                chapterInfo.LessonInfos.Select(ToBusiness)
            );
        }

        public static CourseInfo ToBusiness(Backend.Users.CourseInfo courseInfo)
        {
            if (courseInfo == null) throw new ArgumentNullException(nameof(courseInfo));

            return new CourseInfo
            (
                courseInfo.CourseName,
                courseInfo.Started,
                courseInfo.Completed, 
                courseInfo.ChapterInfos.Select(ToBusiness)
            );
        }

        public static Backend.Users.User ToBackend(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return new Backend.Users.User
            {
                Name = user.Name,
                CourseInfos = user.CourseInfos.Select(ToBackend)
            };
        }

        public static Backend.Users.LessonInfo ToBackend(LessonInfo lessonInfo)
        {
            if(lessonInfo == null) throw new ArgumentNullException(nameof(lessonInfo));

            return new Backend.Users.LessonInfo
            {
                Started = lessonInfo.Started,
                Completed = lessonInfo.Completed,
                LessonName = lessonInfo.LessonName
            };
        }

        public static Backend.Users.ChapterInfo ToBackend(ChapterInfo chapterInfo)
        {
            if (chapterInfo == null) throw new ArgumentNullException(nameof(chapterInfo));

            return new Backend.Users.ChapterInfo
            {
                Started = chapterInfo.Started,
                Completed = chapterInfo.Completed,
                ChapterName = chapterInfo.ChapterName
            };
        }

        public static Backend.Users.CourseInfo ToBackend(CourseInfo courseInfo)
        {
            if(courseInfo == null) throw new ArgumentNullException(nameof(courseInfo));

            return new Backend.Users.CourseInfo
            {
                Completed = courseInfo.Completed,
                Started = courseInfo.Started,
                CourseName = courseInfo.CourseName
            };
        }

    }
}