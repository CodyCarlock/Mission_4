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
        private MoviesContext daContext { get; set; }
        public int MovieId { get; private set; }

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
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult addMovie(applicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();

                return View("confermation", ar);
            }
            else
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View();
            }

            
        }

        [HttpGet]
        public IActionResult movieTable()
        {
            var applications = daContext.Responses
                .Include(x => x.Categories)
                .OrderBy(x => x.Name)
                .ToList();

            return View(applications);
            
        }


        //Edit get and post
        //passes the movieId selected

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = daContext.Categories.ToList();

                                                    //Checks to which movie ID matches the movieId passed
            var movie  = daContext.Responses.Single(x => x.MovieId == id); //not working

            return View("addMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit (applicationResponse blah)
        {
            daContext.Update(blah);
            daContext.SaveChanges();

            return RedirectToAction("movieTable");
        }



        //Delete get and post
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = daContext.Responses.Single(x => x.MovieId == id); 

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete (applicationResponse ar)
        {
            daContext.Responses.Remove(ar);
            daContext.SaveChanges();
            return RedirectToAction("movieTable");
        }
    }
}
