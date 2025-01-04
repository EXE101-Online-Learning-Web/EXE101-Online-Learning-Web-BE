using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourse();
        Task<Course> GetCourseById(int id);
    }
}
