using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimo.Backend.Courses.Migrations
{
    [DbContext(typeof(CoursesContext))]
    [Migration("20170218000000_Initial")]
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Chapter_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ChapterName = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Lesson_Chapter_ChapterName",
                        column: x => x.ChapterName,
                        principalTable: "Chapter",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_CourseName",
                table: "Chapter",
                column: "CourseName");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ChapterName",
                table: "Lesson",
                column: "ChapterName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "Courses");
        }

        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
