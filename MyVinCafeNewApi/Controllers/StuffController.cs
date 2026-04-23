using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using MyVinCafeNewApi.Feature.StuffManagement;
using MyVinCafeNewLibrary.Dtos.StuffDto;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuffController : ControllerBase
    {
        private readonly IStuffService _stuffService;
        public StuffController(IStuffService stuffService)
        {
            _stuffService = stuffService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStuff()
        {
            var request = _stuffService.GetStuffAsync();
            return Ok(request);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStuffById(int id)
        {
            var request = _stuffService.GetStuffByIdAsync(id);
            return Ok(request);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStuff(int id, StuffAdd request)
        {
            var exiting = _stuffService.UpdateStuffAsync(id, request);
            return Ok(exiting);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuff(int id)
        {
            var requset = _stuffService.DeleteStuffAsync(id);
            return Ok(requset);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ManageStuff(int id, StuffQuantityDto request)
        {
            var exiting = _stuffService.ManageStuffAsync(id, request);
            return Ok(exiting);
        }
    }
}
