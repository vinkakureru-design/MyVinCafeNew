using Microsoft.EntityFrameworkCore;
using MyVinCafeNewApi.Feature.StuffManagement;
using MyVinCafeNewLibrary.Data;
using MyVinCafeNewLibrary.Dtos;
using MyVinCafeNewLibrary.Dtos.StuffDto;
using System.Reflection;

namespace MyVinCafeNewApi.Feature.StuffManagement
{
    public class StuffService : IStuffService
    {
        private readonly AppDbContext _context;
        public StuffService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StuffModel>> GetStuffAsync()
        {
            var findStuff = await _context.Stuffs.ToListAsync();
            if (findStuff == null) throw new KeyNotFoundException("Barang kosong");
            return findStuff;
        }

        public async Task<StuffModel> GetStuffByIdAsync(int id)
        {
            var findStuff = await _context.Stuffs.FindAsync(id);
            if (findStuff == null) throw new KeyNotFoundException("Barang tidak ditemukan!");
            return findStuff;
        }

        public async Task<bool> CreateStuffAsync(StuffAdd request)
        {
            var stuffNew = new StuffModel
            {
                IdTools = request.IdStuff,
                NameTools = request.NameTools,
                Deskription = request.Description,
                QuantityHave = request.QuantityHave,
                QuantityNeed = request.QuantityNeed,
                ImageTools = request.ImageTools,
                CreateAt = request.CreateAt
            };

            _context.Stuffs.Add(stuffNew);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<StuffModel> UpdateStuffAsync(int id, StuffAdd request)
        {
            var findStuff = await _context.Stuffs.FindAsync(id);
            if (findStuff == null) throw new KeyNotFoundException("Barang tidak ditemukan!");

            findStuff.NameTools = request.NameTools;
            findStuff.Deskription = request.Description;
            findStuff.QuantityNeed = request.QuantityNeed;
            findStuff.QuantityHave = request.QuantityHave;
            findStuff.ImageTools = request.ImageTools;
            await _context.SaveChangesAsync();
            return findStuff;
        }
        public async Task<bool> DeleteStuffAsync(int id)
        {
            var findStuff = await _context.Stuffs.FindAsync(id);
            if (findStuff == null)
            {
                throw new KeyNotFoundException("Menu tidak ditemukan.");
            }
            _context.Stuffs.Remove(findStuff);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StuffModel> ManageStuffAsync(int id, StuffQuantityDto request)
        {
            var findStuff = await _context.Stuffs.FindAsync(id);
            if (findStuff == null)
            {
                throw new KeyNotFoundException("Barang tidak ditemukan!");
            }

            findStuff.QuantityHave = request.QuantityHave;
            findStuff.QuantityNeed = request.QuantityNeed;
            await _context.SaveChangesAsync();
            return findStuff;
        }
    }
}
