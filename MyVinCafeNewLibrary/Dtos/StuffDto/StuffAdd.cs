using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVinCafeNewLibrary.Dtos.StuffDto
{
    public class StuffAdd
    {
        [Key] public int IdStuff { get; set; }
        [Required] public string NameTools { get; set; } = string.Empty;
        [Required] public string Description { get; set; } = string.Empty;
        [Required] public int QuantityNeed { get; set; }
        [Required] public int QuantityHave{ get; set; }
        public string ImageTools { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
