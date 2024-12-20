﻿using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseTitle { get; set; } = null!;

    public string TeacherId { get; set; }

    public string? Description { get; set; }

    public DateOnly? CreateDate { get; set; }

    public int CategoryId { get; set; }

    public virtual CourseCategory Category { get; set; } = null!;

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<FinalTest> FinalTests { get; set; } = new List<FinalTest>();

    public virtual ICollection<Mooc> Moocs { get; set; } = new List<Mooc>();

    public virtual Account Teacher { get; set; } = null!;
}
