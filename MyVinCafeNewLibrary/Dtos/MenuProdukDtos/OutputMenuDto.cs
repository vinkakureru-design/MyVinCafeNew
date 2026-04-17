using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Dtos.MenuProdukDtos
{
    public class OutputMenuDto
    {
        public string NamaMenu { get; set; } = string.Empty;
        public decimal Harga { get; set; } = 0;
        public string Deskripsi { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        public string GambarUrl { get; set; } = string.Empty;
    }
}
