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
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var allnotes = DbConnector.Query("SELECT * FROM notes ORDER BY created_at DESC");
            ViewBag.allNotes = allnotes;
            return View("Note");
        }

        [HttpPost]
        [Route("notes")]
        public IActionResult AddNote(string title, string description)
        {
            DbConnector.Execute($"INSERT INTO notes (title, description, created_at, updated_at) VALUES ('{title}', '{description}', NOW(), NOW())");
            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Route("notes/{id}")]
        public IActionResult DeleteNote(int id)
        {
            DbConnector.Execute($"DELETE FROM notes WHERE id = {id}");
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