using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required, Display(Name="First Name"), RegularExpression(@"^[a-zA-Z]+$")]
        [MinLength(3, ErrorMessage="First Name must be at least 3 characters.")]
        public string FirstName { get; set; }
        
        [Required, Display(Name="Last Name"), RegularExpression(@"^[a-zA-Z]+$")]
        [MinLength(3, ErrorMessage="Last Name must be at least 3 characters.")]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [ MinLength(8, ErrorMessage="Password must be at least 8 characters.")]
        public string Password { get; set; }
        
        [Required, Display(Name="Confirm Password")]
        [Compare("Password", ErrorMessage="Password and confirmation must match.")]
        public string PasswordConfirmation { get; set; }
    }
}