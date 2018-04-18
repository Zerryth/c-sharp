using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
{
    public class UsersController : Controller
    {
        private BankAccountsContext _context;

        public UsersController(BankAccountsContext context)
        {
            _context = context;
        }

        [HttpPost, Route("/users")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };
                _context.Add(newUser);
                _context.SaveChanges();

                HttpContext.Session.SetString("UserName", newUser.FirstName + " " + newUser.LastName);
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Account", "Transactions", new {userId = newUser.UserId}); 
            }
            return View("Registration");
        }
        
        [HttpGet, Route("/login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost, Route("/login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.SingleOrDefault(u => u.Email == model.Email);
                if (existingUser != null) // email found in DB
                {
                    if (existingUser.Password == model.Password) // password matches
                    {
                        HttpContext.Session.SetString("UserName", existingUser.FirstName + " " + existingUser.LastName);
                        HttpContext.Session.SetInt32("UserId", existingUser.UserId);
                        return RedirectToAction("Account", "Transactions", new {userId = existingUser.UserId});
                    }
                    else
                    {
                        model.PasswordError = 1; // out of Range(0,0) => pw match is false
                        TryValidateModel(model);
                    }
                }
                else
                {
                    model.EmailInDb = 1; // out of Range(0,0) => Email match is false
                    TryValidateModel(model);
                }
            }
            return View("Login");
        }

        [HttpGet, Route("")]
        public IActionResult ShowRegistrationForm()
        {
            return View("Registration");
        }
    }
}