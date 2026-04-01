using MyVinCafeNewLibrary.Models;
using MyVinCafeNewLibrary.Dtos;

namespace MyVinCafeNewApi.Features.UserManagement
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(UserRegisterDto request);
        Task<string> LoginAsync(UserLoginDto request);
    }
}
