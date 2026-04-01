using MyVinCafeNewLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace MyVinCafeNewApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MenuList> MenuLists { get; set; }
        public DbSet<TransaksiHistory> TransaksiHistorys { get; set; }

    }
}
