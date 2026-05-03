using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewLibrary.Dtos.MenuProdukDtos
{
    public class InputMenuDto
    {
        [Key] public int Id { get; set; }
        [Required] public string NamaMenu { get; set; } = string.Empty;
        [Required] public double Harga { get; set; } = 0;
        public string Deskripsi { get; set; } = string.Empty;
        public string GambarUrl { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        [Required] public bool IsAvailable { get; set; } = true;
    }
}
