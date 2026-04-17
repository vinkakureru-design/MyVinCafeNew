using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewShared.Dtos.UserManagement
{
    public class AuthLoginDto
    {
        [Required] public string UserName { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
    }
}
