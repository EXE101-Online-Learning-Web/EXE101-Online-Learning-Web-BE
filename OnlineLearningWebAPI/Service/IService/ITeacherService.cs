using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.TeacherRequest;
using OnlineLearningWebAPI.DTOs.Response.TeacherResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ITeacherService  
    {
        Task<TeacherAccountDTO?> GetTeacherByIdAsync(string id);
        Task<List<TeacherAccountDTO>> GetAllTeachersAsync();
        Task<bool> UpdateTeacherDetailsAsync(string id, UpdateTeacherDTO updateTeacherDTO);
    }
}
