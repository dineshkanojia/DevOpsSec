using Library.Common;
using Library.Infrastructure;
using LibraryApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryApp.Controllers
{
    /// <summary>
    /// Controller to accept book related requests.
    /// </summary>

    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<LibraryAppIdentityUser> _userManager;
        public BookController(LibraryContext db, UserManager<LibraryAppIdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            @TempData["role"] = string.Empty;
            IEnumerable<Book> books = _db.Book;
            string user_name = _userManager.GetUserName(User);
            string role_name = _db.UserRole.Where(x => x.UserName == user_name).FirstOrDefault().Role.ToString();
            if (role_name != null)
                TempData["role"] = role_name;
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book, IFormFile files)
        {
            var bookId = Guid.NewGuid();
            bool IsBookExists = _db.Book.Any(u => u.BookName == book.BookName && u.PublisherName == book.PublisherName && u.AutherName == book.AutherName
            && u.PublishedDate == book.PublishedDate && u.Version == book.Version);
            if (!IsBookExists)
            {
                if (files != null)
                {
                    if (files.Length > 0)
                    {
                        using (var target = new MemoryStream())
                        {
                            files.CopyTo(target);
                            book.FileContents = target.ToArray();
                        }
                    }
                }
                book.FileName = files.FileName;
                book.BookId = bookId;
                _db.Book.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public IActionResult Delete(Guid? BookId)
        {
            if (BookId == null || Guid.Empty == BookId)
            {
                return NotFound();
            }
            var obj = _db.Book.FirstOrDefault(u => u.BookId == BookId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
            // return View();
        }
        [HttpPost]
        public IActionResult DeletePost(Guid? BookId)
        {
            var book = _db.Book.FirstOrDefault(u => u.BookId == BookId);

            if (book != null)
            {
                book.IsDelete = true;
                _db.Book.Remove(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }
        public IActionResult Update(Guid? bookId)
        {
            if (bookId == null || Guid.Empty == bookId)
            {
                return NotFound();
            }
            var obj = _db.Book.FirstOrDefault(u => u.BookId == bookId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
            // return View();
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            try
            {
                bool bookExists = _db.Book.Any(u => u.BookId == book.BookId);
                if (bookExists)
                {
                    var getbook = _db.Book.FirstOrDefault(u => u.BookId == book.BookId);

                    getbook.AutherName = book.AutherName;
                    getbook.BookName = book.BookName;
                    getbook.BookPrice = book.BookPrice;
                    getbook.FileExtention = book.FileExtention;
                    //getbook.FileName = book.FileName;
                    getbook.PublishedDate = book.PublishedDate;
                    getbook.PublisherName = book.PublisherName;
                    getbook.Quantity = book.Quantity;
                    getbook.Version = book.Version;

                    _db.Book.Update(getbook);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = string.Format("{0}", "Error Occurred");

            }
            return View(book);
        }


        public IActionResult ViewFile(Guid? bookId)
        {
            bool IsBookExists = _db.Book.Any(u => u.BookId == u.BookId);
            if (IsBookExists)
            {
                var book = _db.Book.FirstOrDefault(b => b.BookId == bookId);
                return File(book.FileContents, "application/pdf");
            }
            return View();
        }
    }
}

