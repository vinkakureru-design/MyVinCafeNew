using System;
using System.Collections.Generic;
using System.Text;
using MyVinCafeNewLibrary.Data;
using MyVinCafeNewLibrary.Feature.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace MyVinCafeNewLibrary.Feature.UserManagement
{
    public class KaryawanService : IKaryawanService
    {
        private readonly AppDbContext _context;
        public KaryawanService(AppDbContext context)
        {
            _context = context;
        }

        private class Jabatan()
        {
            public string Kasir = "Kasir";
            public string Supervisor = "Supervisor";
            public string Owner = "Owner";
            public string Admin = "Admin";
        }

        public async Task<List<KaryawanModel>> GetAllKaryawanAsync()
        {
            var karyawan = await _context.Karyawans.ToListAsync();
            if (karyawan == null || karyawan.Count == 0)
            {
                throw new KeyNotFoundException("Karyawan Kosong");
            }
            return karyawan;
        }
        public async Task<KaryawanModel> GetKaryawanByIdAsync(int id)
        {
            var karyawan = await _context.Karyawans.FindAsync(id);
            if (karyawan == null)
            {
                throw new KeyNotFoundException("Karyawan tidak ditemukan");
            }
            return karyawan;
        }
        public async Task<bool> AddKaryawanAsync(KaryawanModel request)
        {
            await _context.Karyawans.AddAsync(request);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<KaryawanModel> UpdateKaryawanAsync(int id, KaryawanModel request)
        {
            var karyawan = await _context.Karyawans.FindAsync(id);
            if (karyawan == null)
            {
                throw new KeyNotFoundException("Karyawan tidak ditemukan");
            }

            karyawan.Nama = request.Nama;
            karyawan.Username = request.Username;
            karyawan.PasswordHash = request.PasswordHash;
            karyawan.Email = request.Email;
            karyawan.Phone = request.Phone;

            _context.Karyawans.Update(karyawan);
            await _context.SaveChangesAsync();

            return karyawan;
        }
        public async Task<bool> DeleteKaryawanAsync(int id)
        {
            var karyawan = await _context.Karyawans.FindAsync(id);
            if (karyawan == null)
            {
                throw new KeyNotFoundException("Karyawan tidak ditemukan");
            }

            _context.Karyawans.Remove(karyawan);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
