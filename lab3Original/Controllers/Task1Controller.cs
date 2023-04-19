using lab3Original.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Xml.Linq;

namespace lab3Original.Controllers
{
    public class Task1Controller : Controller
    {
        public IActionResult Index(string name)
        {
            if(!HttpContext.Session.Keys.Contains("Name"))
            {
                return RedirectToAction("Index", "Home");
            }
            var output = new Output();
            output.task1res = DataProvider.Task1();
            return View(output);
		} 
	}
}
