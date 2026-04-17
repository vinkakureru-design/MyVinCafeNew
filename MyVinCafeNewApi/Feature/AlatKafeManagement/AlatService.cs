using Microsoft.EntityFrameworkCore;
using MyVinCafeNewLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.AlatKafeManagement
{
    public class AlatService : IAlatService
    {
        private readonly AppDbContext _context;
        public AlatService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AlatCafeModel>> GetAllAlatAsync()
        {
            var alatList = await _context.Alats.ToListAsync();
            if (alatList == null || alatList.Count == 0)
            {
                throw new Exception("Alat Habis");
            }
            var alatDtoList = alatList.Select(alat => new AlatCafeModel
            {
                NamaAlat = alat.NamaAlat,
                JumlahAlat = alat.JumlahAlat,
            }).ToList();
            return alatDtoList;
        }

        public async Task<AlatCafeModel> GetAlatByIdAsync(int id)
        {
            var alat = await _context.Alats.FindAsync(id);
            if (alat == null)
            {
                throw new Exception("Alat Tidak Ditemukan");
            }
            var alatDto = new AlatCafeModel
            {
                NamaAlat = alat.NamaAlat,
                JumlahAlat = alat.JumlahAlat,
                HargaAlat = alat.HargaAlat
            };
            return alatDto;
        }

        public async Task<bool> CreateAlatAsync(AlatCafeModel request)
        {
            var alat = new AlatCafeModel
            {
                NamaAlat = request.NamaAlat,
                JumlahAlat = request.JumlahAlat,
                HargaAlat = request.HargaAlat
            };
            _context.Alats.Add(alat);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AlatCafeModel> UpdateAlatAsync(int id, AlatCafeModel request)
        {
            var alat = await _context.Alats.FindAsync(id);
            if (alat == null)
            {
                throw new Exception("Alat Tidak Ditemukan");
            }
            alat.NamaAlat = request.NamaAlat;
            alat.JumlahAlat = request.JumlahAlat;
            alat.HargaAlat = request.HargaAlat;
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<bool> DeleteAlatAsync(int id)
        {
            var alat = await _context.Alats.FindAsync(id);
            if (alat == null)
            {
                throw new Exception("Alat Tidak Ditemukan");
            }
            _context.Alats.Remove(alat);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
