using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.UserManagement
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(AuthModel request);
        Task<AuthModel> LoginAsync(AuthModel request);
    }
}
