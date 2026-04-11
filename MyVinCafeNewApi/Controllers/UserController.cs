using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVinCafeNewLibrary.Feature.UserManagement;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel request)
        {
            var resultLogin = await _userService.LoginAsync(request);
            if (resultLogin)
            {
                return Ok("Login berhasil!");
            }
            else
            {
                return BadRequest("Login gagal!");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel request)
        {
            var resultRegister = await _userService.RegisterAsync(request);
            if (resultRegister)
            {
                return Ok("Registrasi berhasil!");
            }
            else
            {
                return BadRequest("Registrasi gagal!");
            }
        }
    }
}
