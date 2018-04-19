using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Range(0, 0, ErrorMessage="Email not found in database.")]
        public int EmailInDb { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Range(0, 0, ErrorMessage="Password entered does not match password in database.")]
        public int PasswordError { get; set; }

        
    }
}