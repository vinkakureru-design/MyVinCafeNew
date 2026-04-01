using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyVinCafeNewLibrary.Models
{
    public class TransaksiHistory
    {
        [Key]
        public int ThId { get; set; }
        public DateTime TransaksiDate { get; set; }

    }
}
