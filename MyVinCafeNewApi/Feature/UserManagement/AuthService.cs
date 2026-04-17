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
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AuthModel> LoginAsync(AuthModel request)
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
            return new AuthModel
            {
                Username = userDb.Username,
                PasswordHash = ""
            };

        }

        public async Task<bool> RegisterAsync(AuthModel request)
        {
            var cekUsername = await _context.Users.AnyAsync(u => u.Username == request.Username);

            if (cekUsername)
            {
                throw new Exception("Username sudah digunakan");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            var userBaru = new AuthModel
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
