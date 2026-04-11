using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVinCafeNewLibrary.Feature.AlatKafeManagement;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlatCafeController : ControllerBase
    {
        private readonly IAlatService _alatService;

        public AlatCafeController(IAlatService alatService)
        {
            _alatService = alatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlat()
        {
           var alatList = await _alatService.GetAllAlatAsync();
            return Ok(alatList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlatById(int id)
        {
            var alat = await _alatService.GetAlatByIdAsync(id);
            return Ok(alat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlat(AlatCafeModel request)
        {
            var result = await _alatService.CreateAlatAsync(request);
            if (result)
            {
                return Ok("Alat berhasil dibuat");
            }
            return BadRequest("Gagal membuat alat");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlat(int id, AlatCafeModel request)
        {
            var result = await _alatService.UpdateAlatAsync(id, request);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Gagal memperbarui alat");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlat(int id)
        {
            var result = await _alatService.DeleteAlatAsync(id);
            if (result)
            {
                return Ok("Alat berhasil dihapus");
            }
            return BadRequest("Gagal menghapus alat");
        }
    }
}
