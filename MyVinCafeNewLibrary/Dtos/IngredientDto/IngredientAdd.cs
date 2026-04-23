using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewLibrary.Dtos.IngredientDto
{
    public class IngredientAdd
    {
        [Required] public string NamaBahan { get; set; } = string.Empty;
        public string Deskripsi { get; set; } = string.Empty;
        [Required] public int BahanHave { get; set; }
        public int BahanNeed { get; set; }
    }
}
