using MyVinCafeNewLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;
using MyVinCafeNewLibrary.Feature.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyVinCafeNewLibrary.Feature.UserManagement
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> LoginAsync(UserModel request)
        {
            var userDb = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            

            if (userDb == null)
            {
                throw new Exception("Akun tidak ditemukan");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.PasswordHash, userDb.PasswordHash);
            if (!isPasswordValid)
            {
                throw new Exception("Password Salah");
            }

            await _context.SaveChangesAsync();
            return new UserModel
            {
                Username = userDb.Username,
                PasswordHash = ""
            };

        }

        public async Task<bool> RegisterAsync(UserModel request)
        {
            var cekUsername = await _context.Users.AnyAsync(u => u.Username == request.Username);

            if (cekUsername)
            {
                throw new Exception("Username sudah digunakan");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            var userBaru = new UserModel
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                Email = request.Email,
                Phone = request.Phone,
                Role = "Memnber"
            };

            _context.Users.Add(userBaru);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
