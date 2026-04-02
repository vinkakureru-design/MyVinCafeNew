using MyVinCafeNewApi.Data;
using MyVinCafeNewLibrary.Models;
using MyVinCafeNewLibrary.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyVinCafeNewApi.Features.UserManagement
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

                /*
        Task<List<User>> GetAllEmployeAsync();
        Task<User> AddEmployeeAsync(UserRegisterDto request);
        Task<User> UpdateEmployeeAsync(int id, UpdateUserDto request);
        Task<bool> DeleteEmployeeAsync(int id);
         */
        

        public async Task<List<User>> GetAllEmployeAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) { throw new Exception("Pengguna tidak ditemukan!"); }
            return user;
        }
        public async Task<User> AddEmployeeAsync(UserRegisterDto request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
            {
                throw new Exception("Username sudah terpakai!.");
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user  = new User
            {
                FullName = request.FullName,
                Username = request.Username,
                Password = passwordHash,
                Email = request.Email,
                Role = 
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUserAsync(int id, UpdateUserDto request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) { throw new Exception("Pengguna tidak ditemukan!"); }
            user.FullName = request.FullName;
            user.Username = request.Username;
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Email = request.Email;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) { throw new Exception("Pengguna tidak ditemukan!"); }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
