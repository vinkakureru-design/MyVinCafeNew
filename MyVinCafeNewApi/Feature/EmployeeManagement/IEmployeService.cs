using MyVinCafeNewApi.Feature.UserManagement;
using MyVinCafeNewLibrary.Dtos.UserDto;

namespace MyVinCafeNewApi.Feature.EmployeeManagement
{
    public interface IEmployeService
    {
        Task<List<UserModel>> GetAllEmployeeAsync();
        Task<UserModel> GetEmployeeByIdAsync(int id);
        Task<bool> CreateEmployeeAsync(AddEmployeeDto request);
        Task<UserModel> UpdateEmployeeAsync(int id, AddEmployeeDto request);
        Task<bool> DeleteEmployeeAsync(int id);

    }
}
