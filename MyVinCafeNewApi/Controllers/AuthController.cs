using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVinCafeNewLibrary.Feature.UserManagement;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;
        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthModel request)
        {
            var resultLogin = await _userService.LoginAsync(request);
            return Ok(resultLogin);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthModel request)
        {
            var resultRegister = await _userService.RegisterAsync(request);
            return Ok(resultRegister);
        }
    }
}
