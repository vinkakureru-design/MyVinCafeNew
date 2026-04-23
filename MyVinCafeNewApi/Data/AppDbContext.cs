using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyVinCafeNewApi.Feature.MenuManagement;
using MyVinCafeNewApi.Feature.StuffManagement;
using MyVinCafeNewApi.Feature.UserManagement;

namespace MyVinCafeNewLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<MenuModel> Menus { get; set; }
        public DbSet<StuffModel> Stuffs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
