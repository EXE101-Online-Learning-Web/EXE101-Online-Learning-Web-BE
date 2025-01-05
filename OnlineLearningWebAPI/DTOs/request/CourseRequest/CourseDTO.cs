﻿namespace OnlineLearningWebAPI.DTOs.request.CourseRequest
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = null!;
        public string? Description { get; set; }
        public string TeacherId { get; set; } = null!;
        public DateOnly? CreateDate { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
