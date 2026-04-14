using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVinCafeNewLibrary.Feature.OrderManagement;
using System.Runtime.CompilerServices;

namespace MyVinCafeNewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel request)
        {
            var resultCreate = await _orderService.CreateOrderAsync(request);
            return Ok(resultCreate);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderModel request)
        {
            var resultUpdate = await _orderService.UpdateOrderAsync(id, request);
            return Ok(resultUpdate);
        }
        [HttpPatch("complate/{id}")]
        public async Task<IActionResult> OrderComplate(int id)
        {
            var resultComplate = await _orderService.OrderComplate(id);
            return Ok(resultComplate);
        }
        [HttpPatch("cancel/{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var resultCancel = await _orderService.CancelOrder(id);
            return Ok(resultCancel);
        }
    }
}
