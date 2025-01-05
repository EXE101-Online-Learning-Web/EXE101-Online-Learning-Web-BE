using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface ICourseRepository: IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(string teacherId);
        Task<IEnumerable<Course>> GetCoursesByCategoryIdAsync(int categoryId);
    }
}
