using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "You cannot withdraw more than your balance.")]
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public User()
        {
            Transactions = new List<Transaction>();
        }
    }
}