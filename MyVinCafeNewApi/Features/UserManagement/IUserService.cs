using MyVinCafeNewLibrary.Models;
using MyVinCafeNewLibrary.Dtos;

namespace MyVinCafeNewApi.Features.UserManagement
{
    public interface IUserService
    {
        Task<List<User>> GetAllEmployeAsync();
        Task<User> AddEmployeeAsync(UserRegisterDto request);
        Task<User> UpdateEmployeeAsync(int id, UpdateUserDto request);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
