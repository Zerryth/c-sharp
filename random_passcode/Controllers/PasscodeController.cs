using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace random_passcode.Controllers
{
    public class PasscodeController: Controller
    {
        private static Random rand = new Random();

        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View("Passcode");
        }
        
        public string GeneratePasscode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string passcode = new string(Enumerable.Range(1,14).Select(character =>
                chars[rand.Next(chars.Length)]).ToArray());
            return passcode;
        }
        public int IncrementCount(int count)
        {
            count += 1;
            return count;
        }
        [HttpGet]
        [Route("generate/{count}")]
        public JsonResult GetResults(int count)
        {
            System.Console.WriteLine("in GetResults****************");
            System.Console.WriteLine(count);
            Dictionary<string, object> res = new Dictionary<string, object>()
            {
                {"passcode", GeneratePasscode()},
                {"count", IncrementCount(count)}
            };
            return Json(res);
        }
    }
}