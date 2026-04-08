using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MyVinCafeNewLibrary.Feature.MenuProdukManagement
{
    public interface IMenuService
    {
        Task<List<MenuDto>> GetAllMenuAsync();
        Task<MenuDto> GetMenuByIdAsync(int id);
        Task<bool> CreateMenuAsync(MenuTambahDto request);
        Task<MenuDto> UpdateMenuAsync(MenuTambahDto request);
        Task<bool> DeleteMenuAsync(int id);

    }
}
