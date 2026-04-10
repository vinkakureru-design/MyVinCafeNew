using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.UserManagement
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserModel request);
        Task<UserModel> LoginAsync(UserModel request);
    }
}
