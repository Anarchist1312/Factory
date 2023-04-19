using lab3Original.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace lab3Original.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (UserProvider.UserExists(user.Name))
            {
                ModelState.AddModelError("Name", "User already exists.");
            }

            else if(UserProvider.TryAddUser(user))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("Password", "Wrong password.");
            }
            return View();
        }
    }
}
