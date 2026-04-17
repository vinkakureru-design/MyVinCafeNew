using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.MenuProdukManagement
{
    public class MenuModels
    {
        [Key]
        public int IdMenu { get; set; }
        [Required]
        [StringLength(50)]
        public string NamaMenu { get; set; } = null!;
        [Required]
        public decimal Harga { get; set; } = decimal.Zero;
        [Required]
        [StringLength(120)]
        public string Deskripsi { get; set; } = null!;
        [Required]
        public string Kategori { get; set; } = null!;
        [Required]
        public bool IsAvailable { get; set; } = true;
        public string GambarUrl { get; set; } = string.Empty;
    }
}
