using AjaxNotes.Connectors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace AjaxNotes.Controllers
{
    public class NoteController: Controller
    {
        // private DbConnector cnx; // build reference to database connector
        public NoteController() // using controller constructor
        {
            // cnx = new DbConnector(); // to instantiate cnx every time we hit a route
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string query = "SELECT * FROM notes ORDER BY created_at DESC";
            var allnotes = DbConnector.Query(query);
            ViewBag.allNotes = allnotes;
            return View("Note");
        }

        [HttpPost]
        [Route("notes")]
        public IActionResult AddNote(string title, string description)
        {
            string query = $"INSERT INTO notes (title, description, created_at, updated_at) VALUES ('{title}', '{description}', NOW(), NOW())";
            DbConnector.Execute(query);
            
            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Route("notes/{id}")]
        public IActionResult DeleteNote(int id)
        {
            Console.WriteLine("*****************id: " + id);
            string query = $"DELETE FROM notes WHERE id = {id}";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpPut]
        [Route("notes/{id}/{text}/{classes}")]
        public IActionResult UpdateNote(int id, string text, string classes)
        {
            if (Regex.IsMatch(classes, "description"))
            {
                DbConnector.Execute($"UPDATE notes SET description='{text}' WHERE id={id}");
            }
            if (Regex.IsMatch(classes, "title"))
            {
                DbConnector.Execute($"UPDATE notes SET title='{text}' WHERE id={id}");
            }
            return RedirectToAction("Index");
        }
    }
}