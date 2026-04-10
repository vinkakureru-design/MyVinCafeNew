using MyVinCafeNewLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MyVinCafeNewLibrary.Feature.MenuProdukManagement
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;
        public MenuService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<MenuTambahDto>> GetAllMenuAsync()
        {
            var menuList = await _context.Menus.ToListAsync();
            if (menuList == null || menuList.Count == 0)
            {
                throw new Exception("Menu Kosong");
            }
            var menuDtoList = menuList.Select(menu => new MenuTambahDto
            {
                IdMenu = menu.IdMenu,
                NameMenu = menu.NamaMenu,
                Harga = menu.Harga,
                Deskripsi = menu.Deskripsi,
                Kategori = menu.Kategori,
                GambarUrl = menu.GambarUrl
            }).ToList();
            return menuDtoList;
        }

        public async Task<MenuDto> GetMenuByIdAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                throw new Exception("Menu Tidak Ditemukan");
            }

            var menuDto = new MenuDto
            {
                NameMenu = menu.NamaMenu,
                Harga = menu.Harga,
                Deskripsi = menu.Deskripsi,
                Kategori = menu.Kategori,
                GambarUrl = menu.GambarUrl
            };
            return menuDto;
        }

        public async Task<bool> CreateMenuAsync(MenuTambahDto request)
        {
            if (request.Harga <= 0)
            {
                throw new Exception("Harga harus lebih besar dari 0");
            }

            var menuBaru = new MenuModels
            {
                NamaMenu = request.NameMenu,
                Harga = request.Harga,
                Deskripsi = request.Deskripsi,
                Kategori = request.Kategori,
                GambarUrl = request.GambarUrl
            };
            _context.Menus.Add(menuBaru);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<MenuDto> UpdateMenuAsync(MenuTambahDto request)
        {
            var menu = await _context.Menus.FindAsync(request.IdMenu);
            if (menu == null)
            {
                throw new Exception("Menu Tidak Ditemukan");
            }
            if (request.Harga <= 0)
            {
                throw new Exception("Harga harus lebih besar dari 0");
            }

            menu.NamaMenu = request.NameMenu;
            menu.Harga = request.Harga;
            menu.Deskripsi = request.Deskripsi;
            menu.Kategori = request.Kategori;
            menu.GambarUrl = request.GambarUrl;

            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
            return new MenuDto
            {
                NameMenu = menu.NamaMenu,
                Harga = menu.Harga,
                Deskripsi = menu.Deskripsi,
                Kategori = menu.Kategori,
                GambarUrl = menu.GambarUrl
            };
        }

        public async Task<bool> DeleteMenuAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                throw new Exception("Menu Tidak Ditemukan");
            }
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
