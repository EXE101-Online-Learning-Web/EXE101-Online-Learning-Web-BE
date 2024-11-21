using System;
using System.Collections.Generic;

namespace OnlineLearningLibrary.Models;

public partial class Certificate
{
    public int CertificateId { get; set; }

    public string? Image { get; set; }

    public int CourseId { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;
}
