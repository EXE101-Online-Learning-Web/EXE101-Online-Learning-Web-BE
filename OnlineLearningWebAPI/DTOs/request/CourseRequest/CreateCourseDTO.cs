namespace OnlineLearningWebAPI.DTOs.request.CourseRequest
{
    public class CreateCourseDTO
    {
        public string CourseTitle { get; set; } = null!;
        public string? Description { get; set; }
        public string TeacherId { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
