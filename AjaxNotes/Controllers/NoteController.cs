using AjaxNotes.Connectors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AjaxNotes.Controllers
{
    public class NoteController: Controller
    {
        private DbConnector cnx; // build reference to database connector

        public NoteController() // using controller constructor
        {
            cnx = new DbConnector(); // to instantiate cnx every time we hit a route
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Note");
        }
    }
}