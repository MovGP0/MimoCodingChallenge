using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mimo.Backend.Courses.Migrations
{
    [DbContext(typeof(CoursesContext))]
    partial class CoursesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Mimo.Backend.Courses.Chapter", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.Property<int>("Order");

                    b.HasKey("Name");

                    b.HasIndex("CourseName");

                    b.ToTable("Chapter");
                });

            modelBuilder.Entity("Mimo.Backend.Courses.Course", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Mimo.Backend.Courses.Lesson", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChapterName");

                    b.Property<int>("Order");

                    b.HasKey("Name");

                    b.HasIndex("ChapterName");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("Mimo.Backend.Courses.Chapter", b =>
                {
                    b.HasOne("Mimo.Backend.Courses.Course")
                        .WithMany("Chapters")
                        .HasForeignKey("CourseName");
                });

            modelBuilder.Entity("Mimo.Backend.Courses.Lesson", b =>
                {
                    b.HasOne("Mimo.Backend.Courses.Chapter")
                        .WithMany("Lessons")
                        .HasForeignKey("ChapterName");
                });
        }
    }
}
