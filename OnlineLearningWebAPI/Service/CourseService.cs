using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int id)
        {
            //var course = await _courseRepository.GetAllAsync()
            //    .Include(c => c.Category)
            //    .Include(c => c.Teacher)
            //    .FirstOrDefaultAsync(c => c.CourseId == id);

            Course course = null;
            if (course == null) return null;

            return new CourseDTO
            {
                CourseId = course.CourseId,
                CourseTitle = course.CourseTitle,
                TeacherId = course.TeacherId,
                Description = course.Description,
                CreateDate = course.CreateDate,
                CategoryId = course.CategoryId,
                //CategoryName = course.Category.CategoryName,
                //TeacherName = course.Teacher.FullName,
                Tags = course.CourseTags.Select(ct => ct.TagName).ToList()
            };
        }

        public async Task<bool> UpdateCourseAsync(int id, CourseDTO courseDTO)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return false;

            course.CourseTitle = courseDTO.CourseTitle ?? course.CourseTitle;
            course.Description = courseDTO.Description ?? course.Description;
            course.CreateDate = courseDTO.CreateDate ?? course.CreateDate;

            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
                //.Include(c => c.Category)
                //.Include(c => c.Teacher)
                //.ToListAsync();

            return courses.Select(course => new CourseDTO
            {
                CourseId = course.CourseId,
                CourseTitle = course.CourseTitle,
                TeacherId = course.TeacherId,
                Description = course.Description,
                CreateDate = course.CreateDate,
                CategoryId = course.CategoryId,
                CategoryName = course.Category.Name,
                TeacherName = course.Teacher.UserName,
                Tags = course.CourseTags.Select(ct => ct.TagName).ToList()
            });
        }
    }
}
