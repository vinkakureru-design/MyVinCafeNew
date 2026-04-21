using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVinCafeNewApi.Feature.MenuManagement;
using System.Runtime.InteropServices.Marshalling;
using MyVinCafeNewLibrary.Dtos.MenuProdukDtos;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            var menus = await _menuService.GetAllMenuAsync();
            return Ok(menus);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            var menu = await _menuService.GetMenuByIdAsync(id);
            return Ok(menu);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(InputMenuDto request)
        {
            var menu = await _menuService.CreateMenuAsync(request);
            return Ok(menu);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, InputMenuDto request)
        {
            var menu = await _menuService.UpdateMenuAsync(id, request);
            return Ok(menu);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var result = await _menuService.DeleteMenuAsync(id);
            if (result)
            {
                return Ok(new { message = "Menu berhasil dihapus." });
            }
            return BadRequest(new { message = "Gagal menghapus menu." });
        }
    }
}
