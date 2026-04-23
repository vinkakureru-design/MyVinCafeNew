using Microsoft.EntityFrameworkCore;
using MyVinCafeNewLibrary.Data;
using MyVinCafeNewLibrary.Dtos.IngredientDto;

namespace MyVinCafeNewApi.Feature.IngredientManagement
{
    public class IngredientService : IIngredientService
    {
        private readonly AppDbContext _context;
        public IngredientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<IngredientGet>> GetAllAsync()
        {
            var cek = _context.Ingredients.ToListAsync();
            if (cek == null)
            {
                throw new KeyNotFoundException("Bahan kosong!");
            }
            return cek;
        }
        public async Task<IngredientModel> GetAsync(int id)
        {
            var cek = _context.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
            if (cek == null)
            {
                throw new KeyNotFoundException("Bahan tidak ditemukan!");
            }
            return cek;
        }
        public async Task<bool> CreateAsync(IngredientModel request)
        {
            var request = _context.Ingredients.AddAsync();
            // -- lanjut nanti --
        }

        // --- masih berlanjut ---S
    }
}
