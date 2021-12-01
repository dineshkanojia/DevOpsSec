using Library.Common;
using Library.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _db;
        public BookController(LibraryContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _db.Book;
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            var bookId = Guid.NewGuid();
            bool IsBookExists = _db.Book.Any(u => u.BookName == book.BookName && u.PublisherName == book.PublisherName && u.AutherName == book.AutherName
            && u.PublishedDate == book.PublishedDate && u.Version == book.Version);
            if (!IsBookExists)
            {
                book.BookId = bookId;
                _db.Book.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
