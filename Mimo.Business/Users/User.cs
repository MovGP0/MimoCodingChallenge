using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mimo.Business.Users
{
    public sealed class User
    {
        public User(string name, IEnumerable<CourseInfo> courseInfos)
        {
            Name = name;
            CourseInfos = courseInfos.ToImmutableArray();
        }

        public string Name { get; }
        public IEnumerable<CourseInfo> CourseInfos { get; }
    }
}