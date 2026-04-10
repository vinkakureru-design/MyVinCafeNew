using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewLibrary.Feature.AlatKafeManagement
{
    public class AlatCafeModel
    {
        [Key]
        public int IdAlat { get; set; }
        [Required]
        public string NamaAlat { get; set; } = null!;
        [Required]
        public int JumlahAlat { get; set; }
        [Required]
        public decimal HargaAlat { get; set; }
    }
}
