﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TriviaSecurityApi.DTOs.IdentityModels
{
    public class ChangePasswordRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
