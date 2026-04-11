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
            var result = await _menuService.GetAllMenuAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {

            var result = await _menuService.GetMenuByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody ]MenuModels request)
        {
            var result = await _menuService.CreateMenuAsync(request);
            return Ok(new {message = "Menu berhasil ditambahkan"});
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateMenu([FromBody]MenuModels request)
        {
            var update = await _menuService.UpdateMenuAsync(request);
            return Ok(new { message = "Menu berhasil diupdate" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu([FromBody]int id)
        {
            var delete = await _menuService.DeleteMenuAsync(id);
            return Ok(new { message = "Menu berhasil dihapus" });
        }
    }
}
