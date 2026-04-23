using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;

namespace MyVinCafeNewApi.Feature.IngredientManagement
{
    public class IngredientModel
    {
        [Key]
        public int Id { get; set; }
        public string NamaBahan { get; set; } = string.Empty;
        public string Deskripsi { get; set; } = string.Empty;
        public int BahanHave {  get; set; }
        public int BahanNeed { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
