using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDatabaseContext movieContext { get; set; }

        // Constructor
        public HomeController(ILogger<HomeController> logger, MovieDatabaseContext movieName)
        {
            _logger = logger;
            movieContext = movieName;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Show MyPodcasts page
        public IActionResult MyPodcasts()
        {
            return View();
        }

        // Get form for movies
        [HttpGet]
        public IActionResult RatingForm()
        {
            var categories = movieContext.Categories.ToList();
            ViewBag.categories = categories;

            return View();
        }

        // Post form, saved to database
        [HttpPost]
        public IActionResult RatingForm(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(movie);
                movieContext.SaveChanges();
                return View("Success", movie);
            }
            else
            {
                var categories = movieContext.Categories.ToList();
                ViewBag.categories = categories;
                return View();
            }
        }

        [HttpGet]
        public IActionResult ViewAllMovies()
        {
            var movies = movieContext.Movies
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            // Still need to pull from all of the categories available.
            var categories = movieContext.Categories.ToList();
            ViewBag.categories = categories;

            // Pull just the movie you're trying to edit.
            var movie = movieContext.Movies.Single(x => x.Id == movieid);

            return View("RatingForm", movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                movieContext.Update(m);
                movieContext.SaveChanges();

                return RedirectToAction("ViewAllMovies");
            }
            else
            {
                var categories = movieContext.Categories.ToList();
                ViewBag.categories = categories;
                return View("RatingForm", m);
            }
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            // Pull just the movie you're trying to delete.
            var movie = movieContext.Movies.Single(x => x.Id == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie m)
        {
            movieContext.Movies.Remove(m);
            movieContext.SaveChanges();
            return RedirectToAction("ViewAllMovies");
        }
    }
}
