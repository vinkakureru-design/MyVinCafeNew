using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewLibrary.Dtos.MenuProdukDtos
{
    public class InputMenuDto
    {
        [Required] public string NamaMenu { get; set; } = string.Empty;
        [Required] public decimal Harga { get; set; } = 0;
        public string Deskripsi { get; set; } = string.Empty;
        [Required] public string Kategori { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public string GambarUrl { get; set; } = string.Empty;
    }
}
