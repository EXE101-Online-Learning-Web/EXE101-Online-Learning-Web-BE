﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineLearningWebAPI.Data;

#nullable disable

namespace OnlineLearningWebAPI.Migrations
{
    [DbContext(typeof(OnlineLearningDbContext))]
    partial class OnlineLearningDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsBan")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsVip")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.ActivityLog", b =>
                {
                    b.Property<int>("ActivityLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("activityLogId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityLogId"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("accountId");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ActivityLogId");

                    b.HasIndex("AccountId");

                    b.ToTable("ActivityLog", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.AuditEntity", b =>
                {
                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.ToTable("AuditEntity");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Certificate", b =>
                {
                    b.Property<int>("CertificateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("certificateId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CertificateId"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("accountId");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CertificateId");

                    b.HasIndex("AccountId");

                    b.ToTable("Certificate", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("courseId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryId");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("CreateDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.CourseCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("categoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.ToTable("CourseCategory", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.CourseEnrollment", b =>
                {
                    b.Property<int>("CourseEnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("courseEnrollmentId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseEnrollmentId"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("accountId");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("EnrollmentDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ProgressPercentage")
                        .HasColumnType("int");

                    b.HasKey("CourseEnrollmentId");

                    b.HasIndex("AccountId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseEnrollment", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.CourseTag", b =>
                {
                    b.Property<int>("CourseTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("courseTagId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseTagId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseId");

                    b.Property<string>("TagName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("tagName");

                    b.HasKey("CourseTagId")
                        .HasName("PK__CourseTa__E7E342A0200F6BB1");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseTags");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.ExamTest", b =>
                {
                    b.Property<int>("ExamTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("examTestId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamTestId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("createdBy");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<int>("MoocId")
                        .HasColumnType("int")
                        .HasColumnName("moocId");

                    b.Property<string>("TestName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("testName");

                    b.HasKey("ExamTestId")
                        .HasName("PK__ExamTest__DC7B3C15142788E6");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("MoocId");

                    b.ToTable("ExamTest", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("feedbackId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("accountId");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("FeedbackText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("AccountId");

                    b.HasIndex("CourseId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.FinalTest", b =>
                {
                    b.Property<int>("FinalTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("finalTestId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FinalTestId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseId");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool?>("GeneratedFromExamTests")
                        .HasColumnType("bit");

                    b.Property<string>("TestName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FinalTestId");

                    b.HasIndex("CourseId");

                    b.ToTable("FinalTest", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.FinalTestQuiz", b =>
                {
                    b.Property<int>("FinalTestQuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FinalTestQuizId"));

                    b.Property<int>("FinalTestId")
                        .HasColumnType("int");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("FinalTestQuizId");

                    b.HasIndex("FinalTestId");

                    b.HasIndex("QuizId");

                    b.ToTable("FinalTestQuizzes");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Mooc", b =>
                {
                    b.Property<int>("MoocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("moocId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MoocId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseId");

                    b.Property<DateOnly?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("createDate")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool?>("IsPublic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("isPublic");

                    b.HasKey("MoocId")
                        .HasName("PK__MOOC__48B763A16B548D41");

                    b.HasIndex("CourseId");

                    b.ToTable("MOOC", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("quizId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizId"));

                    b.Property<int>("ExamTestId")
                        .HasColumnType("int")
                        .HasColumnName("examTestId");

                    b.Property<int>("MaxScore")
                        .HasColumnType("int")
                        .HasColumnName("maxScore");

                    b.Property<string>("QuizName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("quizName");

                    b.Property<string>("QuizQuestion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("quizQuestion");

                    b.Property<int>("QuizTypeId")
                        .HasColumnType("int")
                        .HasColumnName("quizTypeId");

                    b.HasKey("QuizId")
                        .HasName("PK__Quiz__CFF54C3D65A7B54F");

                    b.HasIndex("ExamTestId");

                    b.HasIndex("QuizTypeId");

                    b.ToTable("Quiz", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.QuizAnswer", b =>
                {
                    b.Property<int>("QuizAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("quizAnswerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizAnswerId"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuizId")
                        .HasColumnType("int")
                        .HasColumnName("quizId");

                    b.HasKey("QuizAnswerId");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizAnswer", (string)null);
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.QuizType", b =>
                {
                    b.Property<int>("QuizTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("quizTypeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizTypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("typeName");

                    b.HasKey("QuizTypeId");

                    b.ToTable("QuizType", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineLearningWebAPI.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.ActivityLog", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Account", "Account")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Certificate", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Account", "Account")
                        .WithMany("Certificates")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Course", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.CourseCategory", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.HasOne("OnlineLearningWebAPI.Models.Account", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.CourseEnrollment", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Account", "Account")
                        .WithMany("CourseEnrollments")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("OnlineLearningWebAPI.Models.Course", "Course")
                        .WithMany("CourseEnrollments")
                        .HasForeignKey("CourseId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.CourseTag", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Course", "Course")
                        .WithMany("CourseTags")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK__CourseTag__cours__5BE2A6F2");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.ExamTest", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Account", "CreatedByNavigation")
                        .WithMany("ExamTests")
                        .HasForeignKey("CreatedBy")
                        .IsRequired()
                        .HasConstraintName("FK__ExamTest__create__52593CB8");

                    b.HasOne("OnlineLearningWebAPI.Models.Mooc", "Mooc")
                        .WithMany("ExamTests")
                        .HasForeignKey("MoocId")
                        .IsRequired()
                        .HasConstraintName("FK__ExamTest__moocId__5165187F");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("Mooc");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Feedback", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Account", "Account")
                        .WithMany("Feedbacks")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("OnlineLearningWebAPI.Models.Course", "Course")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.FinalTest", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Course", "Course")
                        .WithMany("FinalTests")
                        .HasForeignKey("CourseId")
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.FinalTestQuiz", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.FinalTest", "FinalTest")
                        .WithMany("FinalTestQuizzes")
                        .HasForeignKey("FinalTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineLearningWebAPI.Models.Quiz", "Quiz")
                        .WithMany("FinalTestQuizzes")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinalTest");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Mooc", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Course", "Course")
                        .WithMany("Moocs")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK__MOOC__courseId__5070F446");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Quiz", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.ExamTest", "ExamTest")
                        .WithMany("Quizzes")
                        .HasForeignKey("ExamTestId")
                        .IsRequired()
                        .HasConstraintName("FK__Quiz__examTestId__534D60F1");

                    b.HasOne("OnlineLearningWebAPI.Models.QuizType", "QuizType")
                        .WithMany("Quizzes")
                        .HasForeignKey("QuizTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Quiz__quizTypeId__5441852A");

                    b.Navigation("ExamTest");

                    b.Navigation("QuizType");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.QuizAnswer", b =>
                {
                    b.HasOne("OnlineLearningWebAPI.Models.Quiz", "Quiz")
                        .WithMany("QuizAnswers")
                        .HasForeignKey("QuizId")
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Account", b =>
                {
                    b.Navigation("ActivityLogs");

                    b.Navigation("Certificates");

                    b.Navigation("CourseEnrollments");

                    b.Navigation("Courses");

                    b.Navigation("ExamTests");

                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Course", b =>
                {
                    b.Navigation("CourseEnrollments");

                    b.Navigation("CourseTags");

                    b.Navigation("Feedbacks");

                    b.Navigation("FinalTests");

                    b.Navigation("Moocs");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.CourseCategory", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.ExamTest", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.FinalTest", b =>
                {
                    b.Navigation("FinalTestQuizzes");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Mooc", b =>
                {
                    b.Navigation("ExamTests");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.Quiz", b =>
                {
                    b.Navigation("FinalTestQuizzes");

                    b.Navigation("QuizAnswers");
                });

            modelBuilder.Entity("OnlineLearningWebAPI.Models.QuizType", b =>
                {
                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
