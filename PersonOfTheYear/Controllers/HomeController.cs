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
            TimeSelected timeSelected = new TimeSelected(fromYear, toYear);
            return RedirectToAction("Results", timeSelected);
        }

        public IActionResult Results(TimeSelected timeSelected)
        {
            return View(TimePerson.GetPersons(timeSelected));
        }
    }
}
