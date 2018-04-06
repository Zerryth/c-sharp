using System;
using Microsoft.AspNetCore.Http; // represents the incoming side of an individual request
using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View("Home");
        }
    }
}