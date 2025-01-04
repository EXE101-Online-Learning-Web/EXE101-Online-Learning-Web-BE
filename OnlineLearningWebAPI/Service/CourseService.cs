using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseService;

        public CourseService(IRepository<Course> courseService)
        {
            _courseService = courseService;
        }

        public async Task<List<Course>> GetAllCourse()
        {
            var allCourses = await _courseService.GetQuery().Include(x => x.CourseTags).ToListAsync();
            return allCourses;
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course = await _courseService.GetQuery().Include(x => x.CourseTags).Where(x => x.CourseId == id).FirstOrDefaultAsync();
            if(course == null)
            {
                return new Course();
            }
            return course;
        }
    }
}
