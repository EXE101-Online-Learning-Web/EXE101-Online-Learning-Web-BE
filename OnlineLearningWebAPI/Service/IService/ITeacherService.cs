﻿using OnlineLearningWebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ITeacherService  
    {
        Task<TeacherDTO?> GetTeacherByIdAsync(int id);
        Task<bool> UpdateTeacherAsync(int id, TeacherDTO updateTeacherDTO);
    }
}
