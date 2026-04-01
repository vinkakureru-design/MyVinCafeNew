namespace MyVinCafeNewLibrary.Dtos
{
    public class UserRegisterDto
    {
        public required string FullName { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
