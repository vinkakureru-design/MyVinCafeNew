using Microsoft.AspNetCore.Identity;
using MyVinCafeNewLibrary.Feature.UserManagement;
using MyVinCafeNewLibrary.Feature.MenuProdukManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyVinCafeNewLibrary.Feature.OrderManagement
{
    public class OrderModel
    {
        [Key]
        public int IdOrder { get; set; }
        [Required]
        public DateTime TanggalOrder { get; set; } = DateTime.UtcNow;
        public int Quantity { get; set; }
        [Required]
        public decimal TotalHarga { get; set; }
        public string Status { get; set; } = null!;

        public int IdUser { get; set; }
        public int IdMenu { get; set; }
        public AuthModel? UserModel { get; set; }
        public MenuModels? MenuModels { get; set; }
    }
}
