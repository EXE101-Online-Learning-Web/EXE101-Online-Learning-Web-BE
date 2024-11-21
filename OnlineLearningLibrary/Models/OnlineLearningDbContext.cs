using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineLearningLibrary.Models;

namespace OnlineLearningLibrary.Models;

public partial class OnlineLearningDbContext : DbContext
{
    public OnlineLearningDbContext()
    {
    }

    public OnlineLearningDbContext(DbContextOptions<OnlineLearningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseCategory> CourseCategories { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<CourseTag> CourseTags { get; set; }

    public virtual DbSet<ExamTest> ExamTests { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FinalTest> FinalTests { get; set; }

    public virtual DbSet<FinalTestQuiz> FinalTestQuizzes { get; set; }

    public virtual DbSet<Mooc> Moocs { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizAnswer> QuizAnswers { get; set; }

    public virtual DbSet<QuizType> QuizTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        optionsBuilder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__F267251EDDB46253");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("avatar");
            entity.Property(e => e.DateSubscription).HasColumnName("dateSubscription");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("fullName");
            entity.Property(e => e.IsBan)
                .HasDefaultValue(false)
                .HasColumnName("isBan");
            entity.Property(e => e.IsVip)
                .HasDefaultValue(false)
                .HasColumnName("isVip");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("passwordHash");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__roleId__4D94879B");
        });

        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.ActivityLogId).HasName("PK__Activity__1025273EB10ED843");

            entity.ToTable("ActivityLog");

            entity.Property(e => e.ActivityLogId).HasColumnName("activityLogId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Account).WithMany(p => p.ActivityLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ActivityL__accou__5EBF139D");
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId).HasName("PK__Certific__A15CBEAE9DB371B5");

            entity.ToTable("Certificate");

            entity.Property(e => e.CertificateId).HasColumnName("certificateId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");

            entity.HasOne(d => d.Account).WithMany(p => p.Certificates)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__accou__59063A47");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__2AA84FD10A5AAC84");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(255)
                .HasColumnName("courseTitle");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createDate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.TeacherId).HasColumnName("teacherId");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__category__4F7CD00D");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__teacherI__4E88ABD4");
        });

        modelBuilder.Entity<CourseCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__CourseCa__23CAF1D8ACDABDB2");

            entity.ToTable("CourseCategory");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.CourseEnrollmentId).HasName("PK__CourseEn__3E39D9FCB3A7258F");

            entity.ToTable("CourseEnrollment");

            entity.Property(e => e.CourseEnrollmentId).HasColumnName("courseEnrollmentId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("enrollmentDate");
            entity.Property(e => e.IsCompleted)
                .HasDefaultValue(false)
                .HasColumnName("isCompleted");
            entity.Property(e => e.ProgressPercentage)
                .HasDefaultValue(0)
                .HasColumnName("progressPercentage");

            entity.HasOne(d => d.Account).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__accou__5CD6CB2B");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__cours__5DCAEF64");
        });

        modelBuilder.Entity<CourseTag>(entity =>
        {
            entity.HasKey(e => e.CourseTagId).HasName("PK__CourseTa__E7E342A0200F6BB1");

            entity.Property(e => e.CourseTagId).HasColumnName("courseTagId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.TagName)
                .HasMaxLength(255)
                .HasColumnName("tagName");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseTags)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseTag__cours__5BE2A6F2");
        });

        modelBuilder.Entity<ExamTest>(entity =>
        {
            entity.HasKey(e => e.ExamTestId).HasName("PK__ExamTest__DC7B3C15142788E6");

            entity.ToTable("ExamTest");

            entity.Property(e => e.ExamTestId).HasColumnName("examTestId");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.MoocId).HasColumnName("moocId");
            entity.Property(e => e.TestName)
                .HasMaxLength(255)
                .HasColumnName("testName");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ExamTests)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamTest__create__52593CB8");

            entity.HasOne(d => d.Mooc).WithMany(p => p.ExamTests)
                .HasForeignKey(d => d.MoocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamTest__moocId__5165187F");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__2613FD24A887532F");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.FeedbackText).HasColumnName("feedbackText");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Account).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__accoun__59FA5E80");

            entity.HasOne(d => d.Course).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__course__5AEE82B9");
        });

        modelBuilder.Entity<FinalTest>(entity =>
        {
            entity.HasKey(e => e.FinalTestId).HasName("PK__FinalTes__4069E5E8C41EC087");

            entity.ToTable("FinalTest");

            entity.Property(e => e.FinalTestId).HasColumnName("finalTestId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.GeneratedFromExamTests)
                .HasDefaultValue(false)
                .HasColumnName("generatedFromExamTests");
            entity.Property(e => e.TestName)
                .HasMaxLength(255)
                .HasColumnName("testName");

            entity.HasOne(d => d.Course).WithMany(p => p.FinalTests)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FinalTest__cours__5629CD9C");
        });

        modelBuilder.Entity<FinalTestQuiz>(entity =>
        {
            entity.HasKey(e => e.FinalTestQuizId).HasName("PK__FinalTes__55B42615F456CC99");

            entity.ToTable("FinalTestQuiz");

            entity.Property(e => e.FinalTestQuizId).HasColumnName("finalTestQuizId");
            entity.Property(e => e.FinalTestId).HasColumnName("finalTestId");
            entity.Property(e => e.QuizId).HasColumnName("quizId");

            entity.HasOne(d => d.FinalTest).WithMany(p => p.FinalTestQuizzes)
                .HasForeignKey(d => d.FinalTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FinalTest__final__571DF1D5");

            entity.HasOne(d => d.Quiz).WithMany(p => p.FinalTestQuizzes)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FinalTest__quizI__5812160E");
        });

        modelBuilder.Entity<Mooc>(entity =>
        {
            entity.HasKey(e => e.MoocId).HasName("PK__MOOC__48B763A16B548D41");

            entity.ToTable("MOOC");

            entity.Property(e => e.MoocId).HasColumnName("moocId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createDate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnName("isPublic");

            entity.HasOne(d => d.Course).WithMany(p => p.Moocs)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MOOC__courseId__5070F446");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__Quiz__CFF54C3D65A7B54F");

            entity.ToTable("Quiz");

            entity.Property(e => e.QuizId).HasColumnName("quizId");
            entity.Property(e => e.ExamTestId).HasColumnName("examTestId");
            entity.Property(e => e.MaxScore).HasColumnName("maxScore");
            entity.Property(e => e.QuizName)
                .HasMaxLength(255)
                .HasColumnName("quizName");
            entity.Property(e => e.QuizQuestion).HasColumnName("quizQuestion");
            entity.Property(e => e.QuizTypeId).HasColumnName("quizTypeId");

            entity.HasOne(d => d.ExamTest).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.ExamTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quiz__examTestId__534D60F1");

            entity.HasOne(d => d.QuizType).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.QuizTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quiz__quizTypeId__5441852A");
        });

        modelBuilder.Entity<QuizAnswer>(entity =>
        {
            entity.HasKey(e => e.QuizAnswerId).HasName("PK__QuizAnsw__92A9CCA7D3D2EAB4");

            entity.ToTable("QuizAnswer");

            entity.Property(e => e.QuizAnswerId).HasColumnName("quizAnswerId");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.IsCorrect)
                .HasDefaultValue(false)
                .HasColumnName("isCorrect");
            entity.Property(e => e.QuizId).HasColumnName("quizId");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizAnswers)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuizAnswe__quizI__5535A963");
        });

        modelBuilder.Entity<QuizType>(entity =>
        {
            entity.HasKey(e => e.QuizTypeId).HasName("PK__QuizType__6CB946D63325B49A");

            entity.ToTable("QuizType");

            entity.Property(e => e.QuizTypeId).HasColumnName("quizTypeId");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .HasColumnName("typeName");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__CD98462A808B354B");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });



        // Seed data for Role
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, Name = "Admin" },
            new Role { RoleId = 2, Name = "Teacher" },
            new Role { RoleId = 3, Name = "Student" },
            new Role { RoleId = 4, Name = "Vip Student" }
        );

        // Seed data for Account
        modelBuilder.Entity<Account>().HasData(
            new Account { AccountId = 1, FullName = "Admin User", Email = "admin@gmail.com", PasswordHash = "123456", RoleId = 1, IsVip = true, IsBan = false, Avatar = "admin_avatar.png", DateSubscription = new DateOnly(2024, 1, 1) },
            new Account { AccountId = 2, FullName = "Jane Smith", Email = "jane.smith@gmail.com", PasswordHash = "123456", RoleId = 2, IsVip = false, IsBan = false, Avatar = "jane_avatar.png", DateSubscription = new DateOnly(2024, 1, 1) },
            new Account { AccountId = 3, FullName = "John Davis", Email = "john.davis@gmail.com", PasswordHash = "123456", RoleId = 3, IsVip = false, IsBan = true, Avatar = "john_avatar.png", DateSubscription = new DateOnly(2024, 1, 1) }
        );

        // Seed data for CourseCategory
        modelBuilder.Entity<CourseCategory>().HasData(
            new CourseCategory { CategoryId = 1, Name = "Programming" },
            new CourseCategory { CategoryId = 2, Name = "Design" },
            new CourseCategory { CategoryId = 3, Name = "Marketing" }
        );

        // Seed data for Course
        modelBuilder.Entity<Course>().HasData(
            new Course { CourseId = 1, CourseTitle = "C# for Beginners", CategoryId = 1, TeacherId = 2, Description = "Learn the basics of C# programming.", CreateDate = new DateOnly(2024, 1, 1) },
            new Course { CourseId = 2, CourseTitle = "Graphic Design Basics", CategoryId = 2, TeacherId = 2, Description = "Introduction to graphic design principles.", CreateDate = new DateOnly(2024, 1, 1) },
            new Course { CourseId = 3, CourseTitle = "Digital Marketing 101", CategoryId = 3, TeacherId = 2, Description = "Learn the fundamentals of digital marketing.", CreateDate = new DateOnly(2024, 1, 1) }
        );

        // Seed data for CourseTag
        modelBuilder.Entity<CourseTag>().HasData(
            new CourseTag { CourseTagId = 1, CourseId = 1, TagName = "C#" },
            new CourseTag { CourseTagId = 2, CourseId = 2, TagName = "Design" },
            new CourseTag { CourseTagId = 3, CourseId = 3, TagName = "Marketing" }
        );

        // Seed data for CourseEnrollment
        modelBuilder.Entity<CourseEnrollment>().HasData(
            new CourseEnrollment { CourseEnrollmentId = 1, AccountId = 3, CourseId = 1, EnrollmentDate = new DateOnly(2024, 1, 1), IsCompleted = false, ProgressPercentage = 25 },
            new CourseEnrollment { CourseEnrollmentId = 2, AccountId = 3, CourseId = 2, EnrollmentDate = new DateOnly(2024, 1, 1), IsCompleted = false, ProgressPercentage = 50 },
            new CourseEnrollment { CourseEnrollmentId = 3, AccountId = 3, CourseId = 3, EnrollmentDate = new DateOnly(2024, 1, 1), IsCompleted = false, ProgressPercentage = 0 }
        );

        // Seed data for Feedback
        modelBuilder.Entity<Feedback>().HasData(
            new Feedback { FeedbackId = 1, AccountId = 3, CourseId = 1, FeedbackText = "Great course!", Rating = 5 },
            new Feedback { FeedbackId = 2, AccountId = 3, CourseId = 2, FeedbackText = "Very useful.", Rating = 4 },
            new Feedback { FeedbackId = 3, AccountId = 3, CourseId = 3, FeedbackText = "Informative content.", Rating = 5 }
        );

        // Seed data for QuizType
        modelBuilder.Entity<QuizType>().HasData(
            new QuizType { QuizTypeId = 1, TypeName = "Multiple Choice" },
            new QuizType { QuizTypeId = 2, TypeName = "True/False" },
            new QuizType { QuizTypeId = 3, TypeName = "Short Answer" }
        );

        // Seed data for Quiz
        modelBuilder.Entity<Quiz>().HasData(
            new Quiz { QuizId = 1, ExamTestId = 1, QuizTypeId = 1, QuizName = "C# Basics", QuizQuestion = "What is a class in C#?", MaxScore = 10 },
            new Quiz { QuizId = 2, ExamTestId = 2, QuizTypeId = 2, QuizName = "Design Principles", QuizQuestion = "Is design important?", MaxScore = 15 },
            new Quiz { QuizId = 3, ExamTestId = 3, QuizTypeId = 3, QuizName = "Marketing Strategies", QuizQuestion = "Describe the 4Ps of marketing.", MaxScore = 20 }
        );

        // Seed data for QuizAnswer
        modelBuilder.Entity<QuizAnswer>().HasData(
            new QuizAnswer { QuizAnswerId = 1, QuizId = 1, Answer = "A class is a blueprint for objects.", IsCorrect = true },
            new QuizAnswer { QuizAnswerId = 2, QuizId = 1, Answer = "A class is a type of variable.", IsCorrect = false },
            new QuizAnswer { QuizAnswerId = 3, QuizId = 2, Answer = "Yes", IsCorrect = true }
        );

        // Seed data for ExamTest
        modelBuilder.Entity<ExamTest>().HasData(
            new ExamTest { ExamTestId = 1, TestName = "Programming Test", MoocId = 1, CreatedBy = 2, Duration = 60 },
            new ExamTest { ExamTestId = 2, TestName = "Design Test", MoocId = 2, CreatedBy = 2, Duration = 45 },
            new ExamTest { ExamTestId = 3, TestName = "Marketing Test", MoocId = 3, CreatedBy = 2, Duration = 30 }
        );

        // Seed data for Certificate
        modelBuilder.Entity<Certificate>().HasData(
            new Certificate { CertificateId = 1, AccountId = 3, CourseId = 1, Image = "certificate1.jpg" },
            new Certificate { CertificateId = 2, AccountId = 3, CourseId = 2, Image = "certificate2.jpg" },
            new Certificate { CertificateId = 3, AccountId = 3, CourseId = 3, Image = "certificate3.jpg" }
        );

        // Seed data for FinalTest
        modelBuilder.Entity<FinalTest>().HasData(
            new FinalTest { FinalTestId = 1, CourseId = 1, TestName = "Final Test C#", Duration = 120, GeneratedFromExamTests = true },
            new FinalTest { FinalTestId = 2, CourseId = 2, TestName = "Final Test Design", Duration = 90, GeneratedFromExamTests = false },
            new FinalTest { FinalTestId = 3, CourseId = 3, TestName = "Final Test Marketing", Duration = 60, GeneratedFromExamTests = true }
        );

        // Seed data for FinalTestQuiz
        modelBuilder.Entity<FinalTestQuiz>().HasData(
            new FinalTestQuiz { FinalTestQuizId = 1, FinalTestId = 1, QuizId = 1 },
            new FinalTestQuiz { FinalTestQuizId = 2, FinalTestId = 2, QuizId = 2 },
            new FinalTestQuiz { FinalTestQuizId = 3, FinalTestId = 3, QuizId = 3 }
        );

        // Seed data for ActivityLog
        modelBuilder.Entity<ActivityLog>().HasData(
            new ActivityLog { ActivityLogId = 1, AccountId = 3, Action = "Logged In", Details = "User logged into the system.", Timestamp = new DateTime(2024, 1, 1) },
            new ActivityLog { ActivityLogId = 2, AccountId = 3, Action = "Enrolled in Course", Details = "User enrolled in C# for Beginners.", Timestamp = new DateTime(2024, 1, 1) },
            new ActivityLog { ActivityLogId = 3, AccountId = 3, Action = "Completed Quiz", Details = "User completed C# Basics Quiz.", Timestamp = new DateTime(2024, 1, 1) }
        );

        // Seed data for Mooc
        modelBuilder.Entity<Mooc>().HasData(
            new Mooc { MoocId = 1, CourseId = 1, Description = "MOOC for C# basics", IsPublic = true, CreateDate = new DateOnly(2024, 1, 1) },
            new Mooc { MoocId = 2, CourseId = 2, Description = "MOOC for design principles", IsPublic = true, CreateDate = new DateOnly(2024, 1, 1) },
            new Mooc { MoocId = 3, CourseId = 3, Description = "MOOC for marketing strategies", IsPublic = false, CreateDate = new DateOnly(2024, 1, 1) }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
