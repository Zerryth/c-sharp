using Microsoft.EntityFrameworkCore;
using gettingStartedWithEntity.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace gettingStartedWithEntity.Controllers {
    public class ReviewsController : Controller
    {
        private RestauranterContext _context;

        public ReviewsController(RestauranterContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Review> AllReviews = _context.reviews.ToList();
            return View("ReviewForm");
        }

        [HttpGet]
        [Route("/reviews")]
        public IActionResult ShowReviews()
        {
            List<Review> AllReviews = _context.reviews.ToList();
            return Json(AllReviews);
        }

        [HttpPost]
        [Route("reviews")]
        public IActionResult AddReview()
        {
            return RedirectToAction("Index");
        }
    }

}