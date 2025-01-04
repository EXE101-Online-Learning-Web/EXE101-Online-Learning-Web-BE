using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly IRepository<CourseCategory> _categoryRepository;

        public CourseCategoryService(IRepository<CourseCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CourseCategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetAllAsync();
            if (category == null) return null;

            return new CourseCategoryDTO
            {
                //CategoryId = category.i,
                //Name = category.,
                //CourseTitles = category.Courses.Select(c => c.CourseTitle).ToList()
            };
        }

        public async Task<bool> UpdateCategoryAsync(int id, CourseCategoryDTO courseCategoryDTO)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            category.Name = courseCategoryDTO.Name ?? category.Name;

            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CourseCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(category => new CourseCategoryDTO
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                CourseTitles = category.Courses.Select(c => c.CourseTitle).ToList()
            });
        }
    }
}
