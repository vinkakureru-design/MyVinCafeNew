using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewLibrary.Dtos.UserDto
{
    public class AddEmployeeDto
    {
        [Required] public string UserName { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required][Phone] public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Employee { get; set; } = true;
    }
}
