using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="Names are required."), Display(Name = "First Name"), MinLength(2, ErrorMessage="First name must be at least 4 characters.")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage="Names can only contain letters.")]
        public string FirstName { get; set; }
        
        [Required, MinLength(2, ErrorMessage="Last name must be at least 4 characters."), Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage="Names can only contain letters.")]
        public string LastName { get; set; }
         
        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required, MinLength(8, ErrorMessage="Passwords must be at least 8 characters."), DataType(DataType.Password)]
        
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="Password and confirmation must match.")]
        public string ConfirmationPW { get; set; }

        [Range(0,0, ErrorMessage="A user with the same email is already registered the database.")]
        public int IsUnique { get; set; }
    }
}