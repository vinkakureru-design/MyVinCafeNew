using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.AlatKafeManagement
{
    public interface IAlatService
    {
        Task<List<AlatCafeModel>> GetAllAlatAsync();
        Task<AlatCafeModel> GetAlatByIdAsync(int id);
        Task<bool> CreateAlatAsync(AlatCafeModel request);
        Task<AlatCafeModel> UpdateAlatAsync(int id,AlatCafeModel request);
        Task<bool> DeleteAlatAsync(int id);
    }
}
