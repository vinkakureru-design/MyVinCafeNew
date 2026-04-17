using Microsoft.AspNetCore.Http.HttpResults;
using MyVinCafeNewLibrary.Data;
using MyVinCafeNewLibrary.Dtos.UserDto;
using MyVinCafeNewApi.Middleware;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace MyVinCafeNewApi.Feature.UserManagement
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(RegisterUser request)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == request.UserName);
            if (existingUser != null) {
                throw new Exception(new { Message = "Username sudah digunakan" }.ToString());
            }

            var newUser = new UserModel
            {
                Username = request.UserName,
                PasswordHash = request.Password,
                Email = request.Email,
                Phone = request.Phone,
                Role = request.Role
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoginUserAsync(LoginUser request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.UserName);
            if (user == null)
            {
                throw new Exception(new { Message = "Akun tidak ditemukan" }.ToString());
            }
            if (user.PasswordHash != request.Password)
            {
                throw new Exception(new { Message = "Password salah" }.ToString());
            }

            return true;
        }
    }
}
