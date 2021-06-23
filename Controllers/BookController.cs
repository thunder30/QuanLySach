using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab02_QuanLySach.Models;

namespace lab02_QuanLySach.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private static List<Book> books;        
        public string HelloTeacher(string university)
        {
            return "Hello Bui Phu Khuyen - University: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS3 Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 3");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            books = new List<Book>();
            books.Add(new Book(
                1,
                "The Clean Coder: A Code of Conduct for Professional Programmers",
                "Author Robert Martin",
                "/Content/Images/book1cover.png"
                )
            );
            books.Add(new Book(
                2,
                "Clean Architecture: A Craftsman's Guide to Software Structure and Design (Robert C. Martin Series) 1st",
                "Author Robert Martin",
                "/Content/Images/book2cover.png"
                )
            );
            books.Add(new Book(
                3,
                "The Pragmatic Programmer: Your Journey To Mastery, 20th Anniversary Edition (2nd Edition) 2nd",
                "Author  David Thomas - Andrew Hunt",
                "/Content/Images/book3cover.png"
                )
            );            
            return View(books);
        }
        
        public ActionResult EditBook(int Id)
        {
            if (Id == null) return HttpNotFound();

            //Book book = books.Find(s => s.Id == id);

            //books = new List<Book>();
            //books.Add(new Book(
            //    1,
            //    "The Clean Coder: A Code of Conduct for Professional Programmers",
            //    "Author Robert Martin",
            //    "/Content/Images/book1cover.png"
            //    )
            //);
            //books.Add(new Book(
            //    2,
            //    "Clean Architecture: A Craftsman's Guide to Software Structure and Design (Robert C. Martin Series) 1st",
            //    "Author Robert Martin",
            //    "/Content/Images/book2cover.png"
            //    )
            //);
            //books.Add(new Book(
            //    3,
            //    "The Pragmatic Programmer: Your Journey To Mastery, 20th Anniversary Edition (2nd Edition) 2nd",
            //    "Author  David Thomas - Andrew Hunt",
            //    "/Content/Images/book3cover.png"
            //    )
            //);

            Book book = new Book();
            foreach (Book item in books)
            {
                if (item.Id == Id)
                {
                    book = item;
                    break;
                }
            }

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int Id, string Title, string Author, string Image_cover)
        {
            if (Id == null) return HttpNotFound();

            //books = new List<Book>();
            //books.Add(new Book(
            //    1,
            //    "The Clean Coder: A Code of Conduct for Professional Programmers",
            //    "Author Robert Martin",
            //    "/Content/Images/book1cover.png"
            //    )
            //);
            //books.Add(new Book(
            //    2,
            //    "Clean Architecture: A Craftsman's Guide to Software Structure and Design (Robert C. Martin Series) 1st",
            //    "Author Robert Martin",
            //    "/Content/Images/book2cover.png"
            //    )
            //);
            //books.Add(new Book(
            //    3,
            //    "The Pragmatic Programmer: Your Journey To Mastery, 20th Anniversary Edition (2nd Edition) 2nd",
            //    "Author  David Thomas - Andrew Hunt",
            //    "/Content/Images/book3cover.png"
            //    )
            //);

            foreach (Book item in books)
            {
                if (item.Id == Id)
                {
                    item.Author = Author;
                    item.Title = Title;
                    item.Image_cover = Image_cover;
                    break;
                }
            }

            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind(Include = "Id, Title, Author, Image_cover")]Book book)
        //public ActionResult CreateBook(int id, string title, string author, string image)
        {
            //books = new List<Book>();
            //books.Add(new Book(
            //    1,
            //    "The Clean Coder: A Code of Conduct for Professional Programmers",
            //    "Author Robert Martin",
            //    "/Content/Images/book1cover.png"
            //    )
            //);
            //books.Add(new Book(
            //    2,
            //    "Clean Architecture: A Craftsman's Guide to Software Structure and Design (Robert C. Martin Series) 1st",
            //    "Author Robert Martin",
            //    "/Content/Images/book2cover.png"
            //    )
            //);
            //books.Add(new Book(
            //    3,
            //    "The Pragmatic Programmer: Your Journey To Mastery, 20th Anniversary Edition (2nd Edition) 2nd",
            //    "Author  David Thomas - Andrew Hunt",
            //    "/Content/Images/book3cover.png"
            //    )
            //);

            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("","Error Save Data");
            }

            return View("ListBookModel", books);
        }
        
        public ActionResult DeleteBook(int Id)
        {

            //books = new List<Book>();
            //books.Add(new Book(
            //    1,
            //    "The Clean Coder: A Code of Conduct for Professional Programmers",
            //    "Author Robert Martin",
            //    "/Content/Images/book1cover.png"
            //    )
            //);
            //books.Add(new Book(
            //    2,
            //    "Clean Architecture: A Craftsman's Guide to Software Structure and Design (Robert C. Martin Series) 1st",
            //    "Author Robert Martin",
            //    "/Content/Images/book2cover.png"
            //    )
            //);
            //books.Add(new Book(
            //    3,
            //    "The Pragmatic Programmer: Your Journey To Mastery, 20th Anniversary Edition (2nd Edition) 2nd",
            //    "Author  David Thomas - Andrew Hunt",
            //    "/Content/Images/book3cover.png"
            //    )
            //);

            //foreach(Book item in books)
            //{
            //    if(item.Id == Id)
            //    {
            //        books.Remove(item);
            //        break;
            //    }
            //}
            Book book = books.Find(s => s.Id == Id);
            books.Remove(book);

            return View("ListBookModel", books);
        }
    }
}