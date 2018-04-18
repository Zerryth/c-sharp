using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace BankAccounts.Controllers
{
    public class TransactionsController : Controller
    {
        private BankAccountsContext _context;

        public TransactionsController(BankAccountsContext context)
        {
            _context = context;
        }

        [HttpGet, Route("account/{userId}")]
        public IActionResult Account(int userId)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = (int?)HttpContext.Session.GetInt32("UserId");
            if(ViewBag.UserId == userId)
            {
                // User user = _context.Users.SingleOrDefault(u => u.UserId == userId);
                List<User> userWithTransactions = _context.Users.Where(u => u.UserId == userId).Include(u => u.Transactions).ToList();
                User user = userWithTransactions[0];
                                                
                UserAccountBundle UserAccountInfo = new UserAccountBundle 
                {
                    UserModel = user,
                    TransactionModel = new Transaction { UserId = userId }
                };
                return View("Account", UserAccountInfo);
            }
            return RedirectToAction("Login", "Users");
            // return Json(UserAccountInfo);
        }

        // UserModel comes in empty from Bundle after form submission. When setting UserModel to user from query, it doesn't seem to tie in with the model binding errors, and lets negative values through
        [HttpPost, Route("/transactions")]
        // variable is same name as Model inside bundle
        public IActionResult AddTransaction(Transaction TransactionModel) 
        // public IActionResult AddTransaction(UserAccountBundle model) 
        {
            User user = _context.Users.SingleOrDefault(u => u.UserId == TransactionModel.UserId);
            user.Transactions = user.Transactions.OrderByDescending(t => t.CreatedAt).ToList();
            user.Balance += TransactionModel.Amount;

            TryValidateModel(user); // check if balance is < 0 => errors

            if(ModelState.IsValid)
            {
                _context.Transactions.Add(TransactionModel);
                _context.SaveChanges();
                return RedirectToAction("Account", new {userId = user.UserId});
            }
            TempData["error"] = "You cannot withdraw more than your balance.";
            return RedirectToAction("Account", new { userId = user.UserId }); 
        }
    }

}