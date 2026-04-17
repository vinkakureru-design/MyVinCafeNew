using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MyVinCafeNewLibrary.Feature.MenuProdukManagement
{
    public interface IMenuService
    {
        Task<List<MenuModels>> GetAllMenuAsync();
        Task<MenuModels> GetMenuByIdAsync(int id);
        Task<bool> CreateMenuAsync(MenuModels request);
        Task<MenuModels> UpdateMenuAsync(MenuModels request);
        Task<bool> DeleteMenuAsync(int id);
    }
}
