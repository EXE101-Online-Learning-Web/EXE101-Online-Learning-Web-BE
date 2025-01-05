using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly OnlineLearningDbContext _context;

        public CourseRepository(OnlineLearningDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(string teacherId)
        {
            return await _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategoryIdAsync(int categoryId)
        {
            return await _context.Courses
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
