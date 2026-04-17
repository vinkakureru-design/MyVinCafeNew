using Microsoft.AspNetCore.Http.HttpResults;
using MyVinCafeNewApi.Feature.UserManagement;
using MyVinCafeNewApi.Middleware;
using MyVinCafeNewLibrary.Data;
using MyVinCafeNewLibrary.Dtos.UserDto;
using Microsoft.EntityFrameworkCore;

namespace MyVinCafeNewApi.Feature.EmployeeManagement
{
    public class EmployeeService : IEmployeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAllEmployeeAsync()
        {
            var employees = await _context.Users.Where(u => u.Employee == true).ToListAsync();
            if (employees == null || employees.Count == 0)
            {
                throw new Exception(new { Message = "Tidak ada karyawan ditemukan" }.ToString());
            }

            return employees;
        }

        public async Task<UserModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.Employee == true);
            if (employee == null)
            {
                throw new Exception(new { Message = "Karyawan tidak ditemukan" }.ToString());
            }
            return employee;
        }

        public async Task<bool> CreateEmployeeAsync(AddEmployeeDto request)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == request.UserName);
            if (existingUser != null)
            {
                throw new Exception(new { Message = "Username sudah digunakan" }.ToString());
            }

            var newEmployee = new UserModel
            {
                Username = request.UserName,
                PasswordHash = request.Password,
                Email = request.Email,
                Phone = request.Phone,
                Role = request.Role,
                Employee = true
            };
            _context.Users.Add(newEmployee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel> UpdateEmployeeAsync(int id, AddEmployeeDto request)
        {
            var employee = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.Employee == true);
            if (employee == null)
            {
                throw new Exception(new { Message = "Karyawan tidak ditemukan" }.ToString());
            }
            employee.Username = request.UserName;
            employee.PasswordHash = request.Password;
            employee.Email = request.Email;
            employee.Phone = request.Phone;
            employee.Role = request.Role;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.Employee == true);
            if (employee == null)
            {
                throw new Exception(new { Message = "Karyawan tidak ditemukan" }.ToString());
            }
            _context.Users.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
