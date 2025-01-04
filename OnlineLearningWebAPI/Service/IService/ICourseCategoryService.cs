using OnlineLearningWebAPI.DTOs;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ICourseCategoryService
    {
        Task<CourseCategoryDTO?> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, CourseCategoryDTO courseCategoryDTO);
        Task<IEnumerable<CourseCategoryDTO>> GetAllCategoriesAsync();
    }
}
