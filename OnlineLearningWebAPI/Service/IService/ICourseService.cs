using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.CourseRequest;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ICourseService
    {
        Task<List<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> GetCourseByIdAsync(int id);
        Task<bool> CreateCourseAsync(CreateCourseDTO createCourseDTO);
        Task<bool> UpdateCourseAsync(int id, UpdateCourseDTO updateCourseDTO);
        Task<bool> DeleteCourseAsync(int id);
    }
}
