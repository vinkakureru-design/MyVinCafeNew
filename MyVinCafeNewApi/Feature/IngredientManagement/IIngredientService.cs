using MyVinCafeNewLibrary.Dtos.IngredientDto;

namespace MyVinCafeNewApi.Feature.IngredientManagement
{
    public interface IIngredientService
    {
        Task<List<IngredientGet>> GetAllAsync();
        Task<IngredientModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(IngredientModel request);
        Task<IngredientModel> UpdateAsync(int id,IngredientAdd request);
        Task<bool> DeleteAsync(int id);
    }
}
