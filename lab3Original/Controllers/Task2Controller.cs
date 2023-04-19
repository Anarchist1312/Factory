using lab3Original.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace lab3Original.Controllers
{
    public class Task2Controller : Controller
    {
        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains("Name"))
            {
                return RedirectToAction("Index", "Home");
            }

            var result = new Output()
            {
                task2res = DataProvider.Task2()   
            };

			return View(result);
        }
    }
}
