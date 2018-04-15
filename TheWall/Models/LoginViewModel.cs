using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Range(0, 0, ErrorMessage="Email entered does not match any email in database." )]
        public int EmailIsInDB { get; set; }
        [Required]
        public string Password { get; set; }
        
        [Range(0,0, ErrorMessage="Password entered does not match password in database.")]
        public int PasswordError { get; set; }
    }
}