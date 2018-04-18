using System.Collections.Generic;

namespace BankAccounts.Models
{
    public class UserAccountBundle
    {
        public User UserModel { get; set; }
        public Transaction TransactionModel { get; set; }
    }
}