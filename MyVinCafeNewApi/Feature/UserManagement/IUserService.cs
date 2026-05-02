using System;
using MyVinCafeNewLibrary.Dtos.UserDto;

namespace MyVinCafeNewApi.Feature.UserManagement
{
    public interface IUserService
    {
        Task<UserModel> RegisterUserAsync(RegisterUser request);
        Task<bool> LoginUserAsync(LoginUser request);

    }
}
