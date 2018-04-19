using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Range(0,0, ErrorMessage="Email not found in database.")]
        public int EmailInDB { get; set; }

        [Required]
        public string Password { get; set; }

        [Range(0, 0, ErrorMessage="Password does not match password in database.")]
        public int PasswordConfirmation { get; set; }
    }
}