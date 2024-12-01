using OnlineLearningLibrary.DTOs;
using OnlineLearningLibrary.Models;
using OnlineLearningLibrary.Repository.IRepository;
using OnlineLearningLibrary.Service.IService;

namespace OnlineLearningLibrary.Service
{
    public class TeacherSerivce: ITeacherService
    {
        private readonly string TEACHER_ROLE = "Teacher";
        private readonly IRepository<Account> _accountRepository;

        public TeacherSerivce(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        async Task<TeacherDTO?> ITeacherService.GetTeacherByIdAsync(int id)
        {
            var teacher = await _accountRepository.GetByIdAsync(id);
            if (teacher == null || teacher.Role.Name != TEACHER_ROLE) return null;

            return new TeacherDTO
            {
                Id = teacher.AccountId,
                FullName = teacher.FullName,
                Email = teacher.Email,
                Avatar = teacher.Avatar,
                IsVip = teacher.IsVip,
                Role = teacher.Role.Name
            };
        }

        async Task<bool> ITeacherService.UpdateTeacherAsync(int id, TeacherDTO updateTeacherDTO)
        {
            var teacher = await _accountRepository.GetByIdAsync(id);
            if (teacher == null || teacher.Role.Name != TEACHER_ROLE) return false;

            teacher.FullName = updateTeacherDTO.FullName ?? teacher.FullName;
            teacher.Avatar = updateTeacherDTO.Avatar ?? teacher.Avatar;
            teacher.IsVip = updateTeacherDTO.IsVip ?? teacher.IsVip;

            _accountRepository.Update(teacher);
            await _accountRepository.SaveChangesAsync();
            return true;
        }
    }
}
