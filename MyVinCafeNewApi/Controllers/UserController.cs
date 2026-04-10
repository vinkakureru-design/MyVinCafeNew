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
            try
            {
                var result = await _userService.LoginAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel request)
        {
            try
            {
                var result = await _userService.RegisterAsync(request);
                if (result)
                {
                    return Ok("Berhasil menjadi member!");
                }
                else
                {
                    return BadRequest("Gagal mendaftar!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
