using OnlineLearningWebAPI.DTOs.Response.CourseTagResponse;
using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;
using System.Collections.ObjectModel;

namespace OnlineLearningWebAPI.DTOs.Response.CourseResponse
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = null!;
        public string? Description { get; set; }
        public string TeacherId { get; set; } = null!;
        public DateOnly? CreateDate { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string? ImageURL { get; set; } = null!;
        public CourseStatus Status { get; set; }
        public IEnumerable<CourseTagDTO> CourseTags { get; set; }
    }
}
