using System.ComponentModel.DataAnnotations;

namespace MyVinCafeNewApi.Feature.UserManagement
{
    public class UserModel
    {
        [Key] public int Id { get; set; }
        [Required] public string Username { get; set; } = string.Empty;
        [Required] public string PasswordHash { get; set; } = string.Empty;
        [EmailAddress] public string Email { get; set; } = string.Empty;
        [Phone] public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Employee { get; set; } = false;
    }
}
