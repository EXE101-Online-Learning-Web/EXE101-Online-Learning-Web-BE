using OnlineLearningWebAPI.DTOs.request.CourseRequest;
using OnlineLearningWebAPI.DTOs.Response.CourseResponse;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                CourseTitle = c.CourseTitle,
                Description = c.Description,
                TeacherId = c.TeacherId,
            });
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return null;

            return new CourseDTO
            {
                CourseId = course.CourseId,
                CourseTitle = course.CourseTitle,
                Description = course.Description,
                TeacherId = course.TeacherId,
            };
        }

        public async Task<bool> CreateCourseAsync(CreateCourseDTO createCourseDTO)
        {
            var course = new Course
            {
                CourseTitle = createCourseDTO.CourseTitle,
                Description = createCourseDTO.Description,
                TeacherId = createCourseDTO.TeacherId,
                CategoryId = createCourseDTO.CategoryId
            };

            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCourseAsync(int id, UpdateCourseDTO updateCourseDTO)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return false;

            course.CourseTitle = updateCourseDTO.CourseTitle ?? course.CourseTitle;
            course.Description = updateCourseDTO.Description ?? course.Description;
            course.CategoryId = updateCourseDTO.CategoryId ?? course.CategoryId;

            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return false;

            _courseRepository.Delete(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByTeacherIdAsync(string teacherId)
        {
            var courses = await _courseRepository.GetCoursesByTeacherIdAsync(teacherId);
            return courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                CourseTitle = c.CourseTitle,
                Description = c.Description,
                TeacherId = c.TeacherId,
            });
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByCategoryIdAsync(int categoryId)
        {
            var courses = await _courseRepository.GetCoursesByCategoryIdAsync(categoryId);
            return courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                CourseTitle = c.CourseTitle,
                Description = c.Description,
                TeacherId = c.TeacherId,
            });
        }
    }
}
