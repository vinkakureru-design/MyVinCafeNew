using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using MyVinCafeNewLibrary.Data;
using MyVinCafeNewLibrary.Feature.OrderManagement;
using MyVinCafeNewLibrary.Feature.MenuProdukManagement;
using Microsoft.EntityFrameworkCore;

namespace MyVinCafeNewLibrary.Feature.OrderManagement
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        /*
        Task<List<OrderModel>> GetAllOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(int id);
        Task<bool> CreateOrderAsync(OrderModel order);
        Task<bool> UpdateOrderAsync(int id, OrderModel order);
        Task<bool> OrderComplate(int id);
        Task<bool> CancelOrder(int id);
         */

        static class Status
        {
            public const string Menunggu = "Menunggu";
            public const string DiMasak = "DiMasak";
            public const string Selesai = "Selesai";
            public const string Dibatalkan = "Dibatalkan";
        }

        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.UserModel)
                .Include(o => o.MenuModels)
                .ToListAsync();
            if (orders == null || orders.Count == 0)
            {
                throw new Exception("Order Kosong");
            }
            return orders;
        }
        public async Task<OrderModel> GetOrderByIdAsync(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.IdOrder == id);
            if (order == null)
            {
                throw new Exception("Order Tidak Temukan");
            }
            return order;
        }
        public async Task<bool> CreateOrderAsync(OrderModel order)
        {
            var orders = new OrderModel
            {
                IdUser = order.IdUser,
                IdMenu = order.IdMenu,
                Quantity = order.Quantity,
                TotalHarga = order.TotalHarga,
                Status = Status.Menunggu,
                TanggalOrder = DateTime.Now
            };
            _context.Orders.Add(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateOrderAsync(int id, OrderModel order)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.IdOrder == id);
            if (existingOrder == null)
            {
                throw new Exception("Order Tidak Temukan");
            }
            existingOrder.IdUser = order.IdUser;
            existingOrder.IdMenu = order.IdMenu;
            existingOrder.Quantity = order.Quantity;
            existingOrder.TotalHarga = order.TotalHarga;
            existingOrder.TanggalOrder = order.TanggalOrder;
            existingOrder.Status = order.Status;
            _context.Orders.Update(existingOrder);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> OrderComplate(int id)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.IdOrder == id);
            if (existingOrder == null)
            {
                throw new Exception("Order Tidak Temukan");
            }
            existingOrder.Status = Status.Selesai;
            _context.Orders.Update(existingOrder);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CancelOrder(int id)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.IdOrder == id);
            if (existingOrder == null)
            {
                throw new Exception("Order Tidak Temukan");
            }
            existingOrder.Status = Status.Dibatalkan;
            _context.Orders.Update(existingOrder);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}