using Microsoft.AspNetCore.Http; // represents the incoming side of an individual HTTP request
using Microsoft.AspNetCore.Mvc;
using System;

namespace time_display.Controllers
{
    public class TimeController: Controller
    {
        DateTime CurrentTime = DateTime.Now;
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var  theTime = CurrentTime.ToString("MMM d, yyy");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!1");
            Console.WriteLine(theTime);
            return View("Index");
        }
    }
}