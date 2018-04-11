using System.ComponentModel.DataAnnotations;

namespace ValidatingFormSubmission.Models
{
    public class User: BaseEntity
    {
        [Required(ErrorMessage="Names are required.")]
        [MinLength(4, ErrorMessage="First name must be at least 4 characters.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(4, ErrorMessage="Last name must be at least 4 characters.")]
        public string LastName { get; set; }
        [Required] 
        [Range(1, int.MaxValue, ErrorMessage="Please enter your age. Age must be greater than 0.")]
        public int Age { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8, ErrorMessage="Passwords must be at least 8 characters."), DataType(DataType.Password)]
        public string Password { get; set; }

    }
}