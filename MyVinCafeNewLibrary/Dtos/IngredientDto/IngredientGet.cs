using System;
using System.Collections.Generic;
using System.Text;

namespace MyVinCafeNewLibrary.Dtos.IngredientDto
{
    public class IngredientGet
    {
        public string NamaBahan { get; set; } = string.Empty;
        public string Deskripsi {  get; set; } = string.Empty;
        public int BahanHave { get; set; } 
        public int BahanNeed { get; set; }
    }
}
