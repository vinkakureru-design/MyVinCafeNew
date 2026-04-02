using MyVinCafeNewApi.Data;
using MyVinCafeNewLibrary.Dtos;
using MyVinCafeNewLibrary.Models; // Pastikan ini ada untuk model User
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace MyVinCafeNewApi.Features.UserManagement
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<bool> RegisterAsync(UserRegisterDto request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
            {
                throw new Exception("Username sudah terpakai!.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                FullName = request.FullName,
                Username = request.Username,
                Password = passwordHash,
                Email = request.Email,
                Role = "Pelanggan"
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<string> LoginAsync(UserLoginDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null) { throw new Exception("Akun Anda tidak ditemukan!"); }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isPasswordValid) { throw new Exception("Kata sandi Anda salah!"); }

            return GeneratedJwtToken(user);
        }

        
        private string GeneratedJwtToken(User user)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes("my_secret_key_12345");
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("id", user.UserId.ToString()),
                    new System.Security.Claims.Claim("username", user.Username),
                    new System.Security.Claims.Claim("role", user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
