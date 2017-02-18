using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimo.Backend.Users.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20170218000000_Initial")]
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "CourseInfos",
                columns: table => new
                {
                    CourseName = table.Column<string>(nullable: false),
                    Completed = table.Column<DateTime>(nullable: false),
                    Started = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInfos", x => x.CourseName);
                    table.ForeignKey(
                        name: "FK_CourseInfos_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChapterInfos",
                columns: table => new
                {
                    ChapterName = table.Column<string>(nullable: false),
                    Completed = table.Column<DateTime>(nullable: false),
                    CourseInfoCourseName = table.Column<string>(nullable: true),
                    Started = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterInfos", x => x.ChapterName);
                    table.ForeignKey(
                        name: "FK_ChapterInfos_CourseInfos_CourseInfoCourseName",
                        column: x => x.CourseInfoCourseName,
                        principalTable: "CourseInfos",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonInfos",
                columns: table => new
                {
                    LessonName = table.Column<string>(nullable: false),
                    ChapterInfoChapterName = table.Column<string>(nullable: true),
                    Completed = table.Column<DateTime>(nullable: false),
                    Started = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonInfos", x => x.LessonName);
                    table.ForeignKey(
                        name: "FK_LessonInfos_ChapterInfos_ChapterInfoChapterName",
                        column: x => x.ChapterInfoChapterName,
                        principalTable: "ChapterInfos",
                        principalColumn: "ChapterName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterInfos_CourseInfoCourseName",
                table: "ChapterInfos",
                column: "CourseInfoCourseName");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInfos_UserName",
                table: "CourseInfos",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_LessonInfos_ChapterInfoChapterName",
                table: "LessonInfos",
                column: "ChapterInfoChapterName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonInfos");

            migrationBuilder.DropTable(
                name: "ChapterInfos");

            migrationBuilder.DropTable(
                name: "CourseInfos");

            migrationBuilder.DropTable(
                name: "Users");
        }

        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
