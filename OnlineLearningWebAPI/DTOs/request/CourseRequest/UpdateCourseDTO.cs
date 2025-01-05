namespace OnlineLearningWebAPI.DTOs.request.CourseRequest
{
    public class UpdateCourseDTO
    {
        public string? CourseTitle { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
