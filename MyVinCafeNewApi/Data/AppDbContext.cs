using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyVinCafeNewLibrary.Feature.MenuProdukManagement;
using MyVinCafeNewLibrary.Feature.UserManagement;
using MyVinCafeNewLibrary.Feature.AlatKafeManagement;
using MyVinCafeNewLibrary.Feature.OrderManagement;

namespace MyVinCafeNewLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AuthModel> Users { get; set; }
        public DbSet<MenuModels> Menus { get; set; }
        public DbSet<AlatCafeModel> Alats { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<KaryawanModel> Karyawans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
