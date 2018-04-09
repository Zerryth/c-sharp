using quotingDojo.Connectors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace quotingDojo.Controllers
{
    public class QuotesController: Controller
    {
        private DbConnector cnx; // build reference to dbconnector

        public QuotesController() // using controller constructor
        {
            cnx = new DbConnector(); // to instantiate cnx every time we hit a route
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult GetQuotes()
        {
            string query = "SELECT * FROM quotes ORDER BY created_at DESC";
            var allQuotes = cnx.Query(query);
            ViewBag.allQuotes = allQuotes;
            return View("Quotes");
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult AddQuote(string name, string context)
        {
            string query = $"INSERT INTO quotes (name, context, created_at, updated_at) VALUES ('{name}', '{context}', NOW(), NOW())";
            cnx.Execute(query);
            return RedirectToAction("GetQuotes");
        }
    }
}