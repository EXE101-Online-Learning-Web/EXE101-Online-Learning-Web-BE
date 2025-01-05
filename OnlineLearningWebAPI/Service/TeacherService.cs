﻿using Microsoft.AspNetCore.Identity;
using OnlineLearningWebAPI.DTOs.request.TeacherRequest;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly string TEACHER_ROLE = "Teacher";

        private readonly UserManager<Account> _userManager;
        private readonly ILogger<TeacherService> _logger;

        public TeacherService(UserManager<Account> userManager, ILogger<TeacherService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<List<TeacherAccountDTO>> GetAllTeachersAsync()
        {
            var accounts = _userManager.Users.ToList(); 
            var teacherAccounts = new List<TeacherAccountDTO>();

            foreach (var account in accounts)
            {
                var roles = await _userManager.GetRolesAsync(account);
                if (roles.Contains(TEACHER_ROLE))
                {
                    teacherAccounts.Add(new TeacherAccountDTO
                    {
                        Id = account.Id,
                        Email = account.Email,
                        UserName = account.UserName,
                        Avatar = account.Avatar,
                        IsVip = account.IsVip,
                        Role = TEACHER_ROLE
                    });
                }
            }

            return teacherAccounts;
        }

        async Task<TeacherAccountDTO?> ITeacherService.GetTeacherByIdAsync(string id)
        {
            var teacher = await _userManager.FindByIdAsync(id);
            if (teacher == null)
            {
                _logger.LogError($"[TeacherService] | GetTeacherByIdAsync | Teacher not found with ID: {id}");
                return null;
            }

            var roles = await _userManager.GetRolesAsync(teacher);
            if (!roles.Contains(TEACHER_ROLE))
            {
                _logger.LogError($"[TeacherService] | GetTeacherByIdAsync | Teacher with ID: {id} does not have the required role: {TEACHER_ROLE}");
                return null;
            }

            return new TeacherAccountDTO
            {
                Id = teacher.Id,
                UserName = teacher.UserName,
                Email = teacher.Email,
                Avatar = teacher.Avatar,
                IsVip = teacher.IsVip,
                Role = TEACHER_ROLE
            };
        }

        async Task<bool> ITeacherService.UpdateTeacherDetailsAsync(string id, UpdateTeacherDTO updateTeacherDTO)
        {
            var teacher = await _userManager.FindByIdAsync(id);
            if (teacher == null)
            {
                _logger.LogError($"[TeacherService] | UpdateTeacherDetailsAsync | Teacher not found with ID: {id}");
                return false;
            }

            var roles = await _userManager.GetRolesAsync(teacher);
            if (!roles.Contains(TEACHER_ROLE))
            {
                _logger.LogError($"[TeacherService] | UpdateTeacherDetailsAsync | Teacher with ID: {id} does not have the required role: {TEACHER_ROLE}");
                return false;
            }

            teacher.UserName = updateTeacherDTO.UserName ?? teacher.UserName;
            teacher.Avatar = updateTeacherDTO.Avatar ?? teacher.Avatar;
            teacher.IsVip = updateTeacherDTO.IsVip ?? teacher.IsVip;
            teacher.Email = updateTeacherDTO.Email ?? teacher.Email;

            var result = await _userManager.UpdateAsync(teacher);
            if (!result.Succeeded)
            {
                _logger.LogError($"[TeacherService] | UpdateTeacherDetailsAsync | Failed to update teacher with ID: {id}. " +
                    $"Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                return false;
            }
            return true;
        }
    }
}
