﻿using System;
using System.Collections.Generic;

namespace OnlineLearningLibrary.Models;

public partial class CourseEnrollment
{
    public int CourseEnrollmentId { get; set; }

    public int AccountId { get; set; }

    public int CourseId { get; set; }

    public DateOnly? EnrollmentDate { get; set; }

    public int? ProgressPercentage { get; set; }

    public bool? IsCompleted { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}