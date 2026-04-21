using MyVinCafeNewLibrary.Data;
using MyVinCafeNewApi.Feature.MenuManagement;
using MyVinCafeNewLibrary.Dtos.MenuProdukDtos;
using Microsoft.EntityFrameworkCore;

namespace MyVinCafeNewApi.Feature.MenuManagement
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;
        public MenuService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuModel>> GetAllMenuAsync()
        {
            var menus = await _context.Menus.ToListAsync();
            if (menus == null || menus.Count == 0)
            {
                throw new KeyNotFoundException("Menu tidak ditemukan.");
            }
            return menus;
        }

        public async Task<MenuModel> GetMenuByIdAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                throw new KeyNotFoundException("Menu tidak ditemukan.");
            }
            return menu;
        }

        public async Task<bool> CreateMenuAsync(InputMenuDto request)
        {
            var menu = new MenuModel
            {
                NamaMenu = request.NamaMenu,
                Harga = request.Harga,
                Deskripsi = request.Deskripsi,
                GambarUrl = request.GambarUrl,
                Kategori = request.Kategori,
                IsAvailable = request.IsAvailable
            };
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<MenuModel> UpdateMenuAsync(int id, InputMenuDto request)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                throw new KeyNotFoundException("Menu tidak ditemukan.");
            }
            menu.NamaMenu = request.NamaMenu;
            menu.Harga = request.Harga;
            menu.Deskripsi = request.Deskripsi;
            menu.GambarUrl = request.GambarUrl;
            menu.Kategori = request.Kategori;
            menu.IsAvailable = request.IsAvailable;
            await _context.SaveChangesAsync();
            return menu;
        }
        public async Task<bool> DeleteMenuAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                throw new KeyNotFoundException("Menu tidak ditemukan.");
            }
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
