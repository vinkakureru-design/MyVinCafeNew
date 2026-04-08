using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.UserManagement
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserRegister request);
        Task<UserLogin> LoginAsync(UserLogin request);
    }
}
