using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyVinCafeNewLibrary.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public required string FullName { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required, NotNull]
        public required string Password { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Role { get; set; }
    }
}
