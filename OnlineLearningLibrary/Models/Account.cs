using System;
using System.Collections.Generic;

namespace OnlineLearningLibrary.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string? Avatar { get; set; }

    public bool? IsBan { get; set; }

    public bool? IsVip { get; set; }

    public DateOnly? DateSubscription { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<ExamTest> ExamTests { get; set; } = new List<ExamTest>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Role Role { get; set; } = null!;
}
