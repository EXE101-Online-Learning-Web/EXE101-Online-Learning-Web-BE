namespace OnlineLearningWebAPI.DTOs.request.TeacherRequest
{
    public class TeacherAccountDTO
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!; 
        public string UserName { get; set; } = null!; 
        public string? Avatar { get; set; } 
        public bool? IsVip { get; set; } 
        public string Role { get; set; } = "Teacher"; 
    }
}
