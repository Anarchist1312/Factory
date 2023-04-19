using lab3Original.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3Original.Controllers
{
    public class WorkersController : Controller
    {
        public IActionResult Index()
        {
			if (!HttpContext.Session.Keys.Contains("Name"))
			{
				return RedirectToAction("Index", "Home");
			}
            var result = new Output
            {
                outputFactories = DataProvider.workers
            };
            return View(result);
        }
    }
}
