using Microsoft.AspNetCore.Mvc;
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
        private MoviesContext _blahContext { get; set; }
        //constructor
        public HomeController(ILogger<HomeController> logger, MoviesContext someName)
        {
            _logger = logger;
            _blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View("podcast");
        }

        [HttpGet]
        public IActionResult addMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addMovie(applicationResponse ar)
        {
            _blahContext.Add(ar);
            _blahContext.SaveChanges();

            return View("confermation", ar);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
