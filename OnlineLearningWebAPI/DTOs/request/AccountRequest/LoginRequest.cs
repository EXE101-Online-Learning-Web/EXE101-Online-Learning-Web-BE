﻿using System.ComponentModel.DataAnnotations;

namespace OnlineLearningWebAPI.DTOs.request.AccountRequest
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
