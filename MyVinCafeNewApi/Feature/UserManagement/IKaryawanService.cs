using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyVinCafeNewLibrary.Data;

namespace MyVinCafeNewLibrary.Feature.UserManagement
{
    public interface IKaryawanService
    {
        Task<List<KaryawanModel>> GetAllKaryawanAsync();
        Task<KaryawanModel> GetKaryawanByIdAsync(int id);
        Task<bool> AddKaryawanAsync(KaryawanModel request);
        Task<KaryawanModel> UpdateKaryawanAsync(int id, KaryawanModel request);
        Task<bool> DeleteKaryawanAsync(int id);
    }
}
