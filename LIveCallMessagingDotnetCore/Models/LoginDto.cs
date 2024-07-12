using System.ComponentModel.DataAnnotations;

namespace LIveCallMessagingDotnetCore.Models
{
    public class LoginDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class MessageDto
    {
        public int UserId { get; set; }
        public Guid? CometUID { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
    }
}
