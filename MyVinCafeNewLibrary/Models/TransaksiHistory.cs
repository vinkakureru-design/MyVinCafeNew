using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MyVinCafeNewLibrary.Models
{
    public class TransaksiHistory
    {
        [Key]
        public int ThId { get; set; }
        public DateTime TransaksiDate { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        
        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual MenuList? Menu { get; set; }
    }
}
