using Microsoft.EntityFrameworkCore;
using Restauranter.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Restauranter.Controllers
{
    public class ReviewsController : Controller
    {
        private RestauranterContext _context;
        public ReviewsController(RestauranterContext context)
        {
            _context = context;
        }

        [HttpPost, Route("/reviews")]
        public IActionResult AddReview(Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction("ShowReviews");
            }
            return View("ReviewForm");
        }

        [HttpGet, Route("")]
        public IActionResult GoToReviewForm()
        {
            return View("ReviewForm");
        }

        [HttpGet, Route("/reviews")]
        public IActionResult ShowReviews()
        {
            List<Review> AllReviews = (List<Review>)_context.Reviews.OrderByDescending(r => r.CreatedAt).ToList();

            ViewBag.AllReviews = AllReviews;

            return View("Reviews", AllReviews);
            // return Json(ViewBag.AllReviews);
        }

        [HttpGet, Route("/Reviews/Helpful/{reviewId}")]
        public IActionResult Helpful(int reviewId)
        {
            Review RetrievedReview = _context.Reviews.SingleOrDefault(review => review.Id == reviewId);
            RetrievedReview.Helpful = RetrievedReview.Helpful + 1;
            _context.SaveChanges();
            return RedirectToAction("ShowReviews");
        }

        [HttpGet, Route("/Reviews/Unhelpful/{reviewId}")]
        public IActionResult Unhelpful(int reviewId)
        {
            Review RetrievedReview = _context.Reviews.SingleOrDefault(review => review.Id == reviewId);
            RetrievedReview.Unhelpful += 1;
            _context.SaveChanges();
            return RedirectToAction("ShowReviews");
        }
    }
}
    