using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Security.Principal;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.UserManagement
{
    public class UserRegister
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [Phone]
        public string Phone { get; set; } = null!;
        [Required]
        public string Role { get; set; } = null!;
    }
}
