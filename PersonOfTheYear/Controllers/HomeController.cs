using System;
using Microsoft.AspNetCore.Mvc;


namespace PersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
