﻿using Microsoft.AspNetCore.Mvc;
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
        
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RatingForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RatingForm(Movie movie)
        {
            movieContext.Add(movie);
            movieContext.SaveChanges();
            return View("Success", movie);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}