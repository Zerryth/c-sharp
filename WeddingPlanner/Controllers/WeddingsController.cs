using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WeddingPlanner.Controllers
{
    public class WeddingsController : Controller
    {
        private WeddingContext _context;

        public WeddingsController(WeddingContext context)
        {
            _context = context;
        }

        [HttpGet, Route("/details/{weddingId}")]
        public IActionResult Details(int weddingId)
        {
            // Wedding selectedWedding = _context.weddings.SingleOrDefault(w => w.WeddingId == weddingId);
            var selectedWedding = _context.weddings.Include(w => w.Guests).ThenInclude(g => g.User).SingleOrDefault(u => u.WeddingId == weddingId);

            return View("Details", selectedWedding);
            // return Json(selectedWedding);
        }

        [HttpGet, Route("Dashboard")]
        public IActionResult Dashboard()
        {
            ViewBag.UserId = (int?)HttpContext.Session.GetInt32("UserId");
            if(ViewBag.UserId != null)
            {
                List<Wedding> allWeddings = _context.weddings.Include(w => w.Guests).ThenInclude(g => g.User).ToList();
                return View("Dashboard", allWeddings);
                // return Json(allWeddings);
            }
            return RedirectToAction("Login", "Users");
        }

        [HttpGet, Route("/weddings")]
        public IActionResult AddWedding()
        {
            return View("AddWedding");
        }

        [HttpPost, Route("/weddings")]
        public IActionResult AddWedding(Wedding model)
        {
            model.CreatorId = (int?)HttpContext.Session.GetInt32("UserId");
            _context.weddings.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Details", new { WeddingId = model.WeddingId});
        }

        [HttpGet, Route("/weddings/delete/{weddingId}")]
        public IActionResult DeleteWedding(int weddingId)
        {
            Wedding wedding = _context.weddings.SingleOrDefault(w => w.WeddingId == weddingId);
            _context.weddings.Remove(wedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet, Route("/weddings/RSVP/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            User user = _context.users.SingleOrDefault(u => u.UserId == userId);
            WeddingMap map = _context.weddingmap.Where(m => m.WeddingId == weddingId).SingleOrDefault(u => u.UserId == userId);

            if (map != null)
            {
                _context.weddingmap.Remove(map); // un-RSVP if user & wedding are joined
            }
            else 
            {   // RSVP if no join with new WeddingMap link
                _context.weddingmap.Add(new WeddingMap{ WeddingId = weddingId, UserId = (int)userId});
            }
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
            // return Json(map);
        }

    }
}