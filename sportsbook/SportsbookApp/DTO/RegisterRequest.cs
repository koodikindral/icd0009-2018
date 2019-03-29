using System.ComponentModel.DataAnnotations;

namespace SportsbookApp.DTO
{
    public class RegisterRequest
    {
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}