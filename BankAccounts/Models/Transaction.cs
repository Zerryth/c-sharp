using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Transaction : BaseEntity
    {
        public int TransactionId { get; set; }

        [Required]
        public double Amount { get; set; } = 0.00;
        public int UserId { get; set; }

        // public User User { get; set; }
    }
}