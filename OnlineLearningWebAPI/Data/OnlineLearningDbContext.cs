using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineLearningWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningWebAPI.Data
{
    internal class OnlineLearningDbContext : DbContext
    {
        private readonly string APPSETTING_JSON_PATH = "appsettings.json";
        private readonly string CONNECTION_STRING = "DefaultConnection";

        public OnlineLearningDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<ExamTest> ExamTests { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FinalTest> FinalTests { get; set; }
        public DbSet<FinalTestQuiz> FinalTestQuizzes { get; set; }
        public DbSet<Mooc> Moocs { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizAnswer> QuizAnswers { get; set; }
        public DbSet<QuizType> QuizTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(APPSETTING_JSON_PATH, optional: true, reloadOnChange: true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING));
        }
    }
}
