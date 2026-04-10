    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MyVinCafeNewLibrary.Feature.MenuProdukManagement;
    using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuProdukController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuProdukController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            try
            {
                var result = await _menuService.GetAllMenuAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {

            try
            {
                var result = await _menuService.GetMenuByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Menu Tidak Ditemukan")
                {
                    return NotFound(ex.Message);
                }

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody ]MenuTambahDto request)
        {
            try
            {
                var create = await _menuService.CreateMenuAsync(request);
                return Ok(create);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create {ex.Message}");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateMenu([FromBody]MenuTambahDto request)
        {
            try
            {
                var update = await _menuService.UpdateMenuAsync(request);
                return Ok(new {message = "Berhhasil diUpdate"});
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu([FromBody]int id)
        {
            try
            {
                var delete = await _menuService.DeleteMenuAsync(id);
                return Ok(new { message = "Menu berhasil dihapus" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Menu Tidak Ditemukan")
                {
                    return NotFound(new {message = ex.Message});
                }
                return BadRequest( new {message = ex.Message});
            }
        }
    }
}
