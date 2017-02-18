using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mimo.Backend.Users.Migrations
{
    [DbContext(typeof(UsersContext))]
    partial class UsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Mimo.Backend.Users.ChapterInfo", b =>
                {
                    b.Property<string>("ChapterName")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Completed");

                    b.Property<string>("CourseInfoCourseName");

                    b.Property<DateTime>("Started");

                    b.HasKey("ChapterName");

                    b.HasIndex("CourseInfoCourseName");

                    b.ToTable("ChapterInfos");
                });

            modelBuilder.Entity("Mimo.Backend.Users.CourseInfo", b =>
                {
                    b.Property<string>("CourseName")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Completed");

                    b.Property<DateTime>("Started");

                    b.Property<string>("UserName");

                    b.HasKey("CourseName");

                    b.HasIndex("UserName");

                    b.ToTable("CourseInfos");
                });

            modelBuilder.Entity("Mimo.Backend.Users.LessonInfo", b =>
                {
                    b.Property<string>("LessonName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChapterInfoChapterName");

                    b.Property<DateTime>("Completed");

                    b.Property<DateTime>("Started");

                    b.HasKey("LessonName");

                    b.HasIndex("ChapterInfoChapterName");

                    b.ToTable("LessonInfos");
                });

            modelBuilder.Entity("Mimo.Backend.Users.User", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mimo.Backend.Users.ChapterInfo", b =>
                {
                    b.HasOne("Mimo.Backend.Users.CourseInfo")
                        .WithMany("ChapterInfos")
                        .HasForeignKey("CourseInfoCourseName");
                });

            modelBuilder.Entity("Mimo.Backend.Users.CourseInfo", b =>
                {
                    b.HasOne("Mimo.Backend.Users.User")
                        .WithMany("CourseInfos")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("Mimo.Backend.Users.LessonInfo", b =>
                {
                    b.HasOne("Mimo.Backend.Users.ChapterInfo")
                        .WithMany("LessonInfos")
                        .HasForeignKey("ChapterInfoChapterName");
                });
        }
    }
}
