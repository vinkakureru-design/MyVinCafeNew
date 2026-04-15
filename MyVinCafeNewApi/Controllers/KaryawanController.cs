using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Diagnostics;
using System.Security.AccessControl;
using MyVinCafeNewLibrary.Feature.UserManagement;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaryawanController : ControllerBase
    {
        private readonly IKaryawanService _karyawanService;
        public KaryawanController(IKaryawanService karyawanService)
        {
            _karyawanService = karyawanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKaryawan()
        {
            var result = await _karyawanService.GetAllKaryawanAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKaryawanById(int id)
        {
            var result = await _karyawanService.GetKaryawanByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddKaryawan([FromBody] KaryawanModel request)
        {
            var result = await _karyawanService.AddKaryawanAsync(request);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKaryawan(int id, [FromBody] KaryawanModel request)
        {
            var result = await _karyawanService.UpdateKaryawanAsync(id, request);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKaryawan(int id)
        {
            var result = await _karyawanService.DeleteKaryawanAsync(id);
            return Ok(result);
        }
    }
}
