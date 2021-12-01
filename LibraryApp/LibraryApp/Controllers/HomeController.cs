using Library.Common;
using Library.Infrastructure;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _db;
        public HomeController(LibraryContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
