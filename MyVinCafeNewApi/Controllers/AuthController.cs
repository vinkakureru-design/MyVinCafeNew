using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVinCafeNewApi.Feature.UserManagement;
using MyVinCafeNewLibrary.Dtos.UserDto;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser request)
        {
            var result = await _userService.RegisterUserAsync(request);

            if (result == null)
            {
                return BadRequest(new { Message = "Registrasi Gagal" });
            }
            
            return Ok(new { Message = "Registrasi Berhasil" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser request)
        {
            var result = await _userService.LoginUserAsync(request);
            if (result)
            {
                return Ok(new { Message = "Login berhasil" });
            }
            return BadRequest(new { Message = "Login gagal" });
        }
    }
}
