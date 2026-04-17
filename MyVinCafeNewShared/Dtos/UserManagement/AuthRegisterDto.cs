using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewShared.Dtos.UserManagement
{
    public class AuthRegisterDto
    {
        public string? FullName { get; set; }
        [Required] public string UserName { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
        [EmailAddress] public string EmailAddress { get; set; } = null!;
        [Phone] public string PhoneNumber { get; set; } = null!;
    }
}
