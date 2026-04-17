using System;
using MyVinCafeNewLibrary.Dtos.UserDto;

namespace MyVinCafeNewApi.Feature.UserManagement
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUser request);
        Task<bool> LoginUserAsync(LoginUser request);

    }
}
