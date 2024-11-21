﻿using System;
using System.Collections.Generic;

namespace OnlineLearningLibrary.Models;

public partial class CourseCategory
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
