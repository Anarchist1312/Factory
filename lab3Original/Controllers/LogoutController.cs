using Microsoft.AspNetCore.Mvc;

namespace lab3Original.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("Name");
            return RedirectToAction("Index", "Home");
        }
    }
}
