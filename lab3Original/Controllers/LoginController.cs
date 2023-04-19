using lab3Original.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab3Original.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            
            if (UserProvider.isLoggedIn(user)) 
            {
                HttpContext.Session.SetString("Name", user.Name);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Name"," ");
                ModelState.AddModelError("Password", "Invalid username or password.");
            }

            return View();
        }
    }
}