using MyVinCafeNewLibrary.Dtos.MenuProdukDtos;

namespace MyVinCafeNewApi.Feature.MenuManagement
{
    public interface IMenuService
    {
        Task<List<MenuModel>> GetAllMenuAsync();
        Task<MenuModel> GetMenuByIdAsync(int id);

        Task<bool> CreateMenuAsync(InputMenuDto request);
        Task<MenuModel> UpdateMenuAsync(int id, InputMenuDto request);
        Task<bool> DeleteMenuAsync(int id);
    }
}
