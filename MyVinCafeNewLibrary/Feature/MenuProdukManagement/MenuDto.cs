using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.MenuProdukManagement
{
    public class MenuDto
    {
        public string NameMenu { get; set; } = string.Empty;
        public decimal Harga { get; set; } = decimal.Zero;
        public string Deskripsi { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        public string GambarUrl { get; set; } = string.Empty;
    }
}
