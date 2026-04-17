using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.OrderManagement
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetAllOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(int id);
        Task<bool> CreateOrderAsync(OrderModel order);
        Task<bool> UpdateOrderAsync(int id, OrderModel order);
        Task<bool> OrderComplate(int id);
        Task<bool> CancelOrder(int id);
    }
}
