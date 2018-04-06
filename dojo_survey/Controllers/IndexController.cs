using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dojo_survey.Controllers
{
    public class IndexController: Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("submit")]
        public IActionResult Submit(string name, string location, string language, string comment)
        {
            Dictionary<string, string> results = new Dictionary<string, string>()
            {
                {"Name", name},
                {"Location", location},
                {"Language", language},
                {"Comment", comment}
            };

            ViewBag.Result = results;

            foreach (KeyValuePair<string,string> entry in results)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }

            return View("Result");
        }
    }
}