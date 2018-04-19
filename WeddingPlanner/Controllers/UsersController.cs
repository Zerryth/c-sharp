using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
{
    public class UsersController : Controller
    {
        private WeddingContext _context;

        public UsersController(WeddingContext context)
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
                return RedirectToAction("Dashboard", "Weddings"); 
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
                var existingUser = _context.users.SingleOrDefault(u => u.Email == model.Email);
                if (existingUser != null) // email found in DB
                {
                    if (existingUser.Password == model.Password) // password matches
                    {
                        HttpContext.Session.SetString("UserName", existingUser.FirstName + " " + existingUser.LastName);
                        HttpContext.Session.SetInt32("UserId", existingUser.UserId);
                        return RedirectToAction("Dashboard", "Weddings");
                    }
                    else
                    {
                        model.PasswordConfirmation = 1; // out of Range(0,0) => pw match is false
                        TryValidateModel(model);
                    }
                }
                else
                {
                    model.EmailInDB = 1; // out of Range(0,0) => Email match is false
                    TryValidateModel(model);
                }
            }
            return View("Login");
        }

        [HttpGet, Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet, Route("")]
        public IActionResult ShowRegistrationForm()
        {
            return View("Registration");
        }
    }
}