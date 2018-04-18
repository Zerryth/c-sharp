using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;

namespace BankAccounts.Models
{
    public class BankAccountsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankAccountsContext(DbContextOptions<BankAccountsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}