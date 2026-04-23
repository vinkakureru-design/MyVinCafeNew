using System.ComponentModel.DataAnnotations;

namespace MyVinCafeNewApi.Feature.StuffManagement
{
    public class StuffModel
    {
        [Key] public int IdTools { get; set; }
        public string NameTools { get; set; } = string.Empty;
        public int QuantityNeed { get; set; }
        public int QuantityHave { get; set; }
        public string Deskription { get; set; } = string.Empty;
        public string ImageTools { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    }
}
