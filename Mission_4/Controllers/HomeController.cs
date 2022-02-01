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
        private MoviesContext daContext { get; set; }
        //constructor
        public HomeController(MoviesContext someName)
        {
            daContext = someName;
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
            daContext.Add(ar);
            daContext.SaveChanges();

            return View("confermation", ar);
        }

        [HttpGet]
        public IActionResult movieTable()
        {
            var applications = daContext.Responses.ToList();
            return View(applications);
            
        }

    }
}
