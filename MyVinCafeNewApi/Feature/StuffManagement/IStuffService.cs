using MyVinCafeNewLibrary.Dtos.StuffDto;

namespace MyVinCafeNewApi.Feature.StuffManagement
{
    public interface IStuffService
    {
        Task<List<StuffModel>> GetStuffAsync();
        Task<StuffModel> GetStuffByIdAsync(int id);
        Task<bool> CreateStuffAsync(StuffAdd request);
        Task<StuffModel> UpdateStuffAsync(int id, StuffAdd request);
        Task<bool> DeleteStuffAsync(int id);

        Task<StuffModel> ManageStuffAsync(int id, StuffQuantityDto request);

    }
}
