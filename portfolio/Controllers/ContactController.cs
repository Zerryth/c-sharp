using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers
{
    public class ContactController: Controller
    {
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View ("Contact");
        }
        [HttpPost]
        [Route("SubmitContact")]
        public IActionResult SubmitContact(string name, string email, string text)
        {
            Console.WriteLine($"Contact: {name}, {email}, {text}");
            ViewBag.ContactInfo = $"Contact: {name}, {email}, {text}";
            return View("Contact");
        }
    }
}