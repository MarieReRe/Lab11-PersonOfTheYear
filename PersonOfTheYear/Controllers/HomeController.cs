using System;
using Microsoft.AspNetCore.Mvc;
using PersonOfTheYear.Models;

namespace PersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        //Index is the default page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int fromYear, int toYear)
        {
            return RedirectToAction("Results", new { fromYear, toYear });
        }

        public IActionResult Results(int fromYear, int toYear)
        {
            return View(TimePerson.GetPersons(fromYear, toYear));
        }
    }
}
