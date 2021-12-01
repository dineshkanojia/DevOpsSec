using Library.Common;
using Library.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public class UserController : Controller
    {
        private readonly LibraryContext _db;
        public UserController(LibraryContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<LoginUser> user = _db.LoginUser.Where(u => u.IsDelete != true).ToList();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoginUser loginUser)
        {
            var userid = Guid.NewGuid();
            bool IsUserExits = _db.LoginUser.Any(u => u.UserId == userid || u.Username == loginUser.Username);
            if (!IsUserExits && ModelState.IsValid)
            {
                loginUser.UserId = userid;
                _db.LoginUser.Add(loginUser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginUser);
        }

        public IActionResult Delete(Guid? UserId)
        {
            if (UserId == null || Guid.Empty == UserId)
            {
                return NotFound();
            }
            var obj = _db.LoginUser.FirstOrDefault(u => u.UserId == UserId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
            // return View();
        }

        [HttpPost]
        public IActionResult DeletePost(Guid? UserId)
        {
            var user = _db.LoginUser.FirstOrDefault(u => u.UserId == UserId);

            if (user != null)
            {
                user.IsDelete = true;
                _db.LoginUser.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Update(Guid? UserId)
        {
            if (UserId == null || Guid.Empty == UserId)
            {
                return NotFound();
            }
            var obj = _db.LoginUser.FirstOrDefault(u => u.UserId == UserId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
            // return View();
        }

        [HttpPost]
        public IActionResult Update(LoginUser loginUser)
        {
            bool IsUserExits = _db.LoginUser.Any(u => u.UserId == loginUser.UserId);
            if (IsUserExits && ModelState.IsValid)
            {
                _db.LoginUser.Update(loginUser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginUser);
        }
    }
}
