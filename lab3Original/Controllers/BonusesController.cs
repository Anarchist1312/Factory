using lab3Original.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3Original.Controllers
{
	public class BonusesController : Controller
	{
		public IActionResult Index()
		{
			if (!HttpContext.Session.Keys.Contains("Name"))
			{
				return RedirectToAction("Index", "Home");
			}
			var result = new Output
			{
				outputBonuses = DataProvider.bonus
			};
			return View(result);
		}
	}
}
