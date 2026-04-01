using System.ComponentModel.DataAnnotations;

namespace MyVinCafeNewLibrary.Models
{
    public class MenuList
    {
        [Key]
        public int MenuId { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
