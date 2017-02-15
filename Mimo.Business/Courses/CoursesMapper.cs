using System.Collections.Generic;
using System.Linq;

namespace Mimo.Business.Courses
{
    public static class CoursesMapper
    {
        public static IEnumerable<Course> ToBusiness(IEnumerable<Backend.Courses.Course> courses)
        {
            return courses.Select(ToBusiness);
        }

        public static Course ToBusiness(Backend.Courses.Course course)
        {
            return new Course
            {
                Name = course.Name,
                Chapters = course.Chapters.Select(ToBusiness).ToList()
            };
        }

        public static Chapter ToBusiness(Backend.Courses.Chapter chapter)
        {
            return new Chapter
            {
                Lessons = chapter.Lessons.Select(ToBusiness).OrderBy(i => i.Order).ToList(), 
                Name = chapter.Name, 
                Order = chapter.Order
            };
        }

        public static Lesson ToBusiness(Backend.Courses.Lesson chapter)
        {
            return new Lesson
            {
                Name = chapter.Name,
                Order = chapter.Order
            };
        }

        public static IEnumerable<Backend.Courses.Course> ToBackend(IEnumerable<Course> courses)
        {
            return courses.Select(ToBackend);
        }

        public static Backend.Courses.Course ToBackend(Course courses)
        {
            return new Backend.Courses.Course
            {
                Name = courses.Name,
                Chapters = courses.Chapters.Select(ToBackend).ToArray()
            };
        }

        public static Backend.Courses.Chapter ToBackend(Chapter chapter)
        {
            return new Backend.Courses.Chapter
            {
                Name = chapter.Name, 
                Order = chapter.Order, 
                Lessons = chapter.Lessons.Select(ToBackend).ToArray()
            };
        }

        public static Backend.Courses.Lesson ToBackend(Lesson lesson)
        {
            return new Backend.Courses.Lesson
            {
                Name = lesson.Name,
                Order = lesson.Order
            };
        }
    }
}