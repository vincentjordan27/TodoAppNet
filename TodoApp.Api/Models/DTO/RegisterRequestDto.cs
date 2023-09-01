﻿using System.ComponentModel.DataAnnotations;

namespace TodoApp.Api.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
