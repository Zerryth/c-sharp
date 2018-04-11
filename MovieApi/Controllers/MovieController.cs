using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MovieApi.Controllers
{
    public class MovieController: Controller
    {
        private readonly DbConnector _dbConnector;

        public MovieController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var allSearchedMovies = _dbConnector.Query("SELECT * FROM movies ORDER BY created_at DESC");
            ViewBag.allSearchedMovies = allSearchedMovies;
            return View();
            // return Json(allSearchedMovies);
        }

        [HttpPost]
        [Route("movie")]
        public IActionResult QueryMovie(string title)
        {
            var MovieInfo = new Dictionary<string, object>();
            WebRequest.GetMovieDataAsync(title, ApiResponse => {
                MovieInfo = ApiResponse;
                JArray moviesArray = (JArray)MovieInfo["results"];

                string movieTitle = (string)moviesArray[0]["title"];
                double rating = (double)moviesArray[0]["vote_average"];
                string releaseDate = (string)moviesArray[0]["release_date"];

                AddSearchedMovieToDb(movieTitle, rating, releaseDate);
            }).Wait();
            
            // return Json();
            return RedirectToAction("Index");
        }

        public void AddSearchedMovieToDb(string title, double rating, string releaseDate)
        {
            _dbConnector.Execute($"INSERT INTO movies (title, rating, release_date, created_at, updated_at) VALUES ('{title}', '{rating}', '{releaseDate}', NOW(), NOW())");
        }
    }
}