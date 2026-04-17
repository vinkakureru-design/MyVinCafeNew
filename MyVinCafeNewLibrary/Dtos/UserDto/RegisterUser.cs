using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewLibrary.Dtos.UserDto
{
    public class RegisterUser
    {
        [Required] public string UserName { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
        [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] [Phone] public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = "Member";
        public bool Employee { get; set; } = false;
    }
}
