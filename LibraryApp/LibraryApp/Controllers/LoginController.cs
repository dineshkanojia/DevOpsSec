using Library.Common;
using Library.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    /// <summary>
    /// Login Controller added to serve login users.
    /// </summary>
    public class LoginController : Controller
    {
        private readonly LibraryContext _db;
        public LoginController(LibraryContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginUser)
        {
            @TempData["LoginMessage"] = string.Empty;
            if (!string.IsNullOrEmpty(loginUser.Username) && !string.IsNullOrEmpty(loginUser.Password))
            {
                var isUserExist = _db.LoginUser.Any(u=> u.Username == loginUser.Username && u.Password == loginUser.Password);
                if (isUserExist)
                {
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    TempData["LoginMessage"] = "Invalid username or password.";
                    return RedirectToAction("Index", "Login");
                }
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
