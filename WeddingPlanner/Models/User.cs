using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<WeddingMap> WeddingsToAttend { get; set; }

        public User()
        {
            WeddingsToAttend = new List<WeddingMap>();
        }
    }
}