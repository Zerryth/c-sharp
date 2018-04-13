using System.ComponentModel.DataAnnotations;
using System;

namespace LoginReg.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
         
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string ConfirmationPW { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}