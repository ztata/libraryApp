using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libraryApp.Models.libraryItems;
using libraryApp.Models.Context;

namespace libraryApp.Controllers
{
    public class LoggedInUserController : Controller
    {
        // GET: LoggedInUserController
        public ActionResult Index(string genre = "null", bool seeAllBooks = false)
        {
            List<Book> books = null;
            using (libContext context = new libContext())
            {
                //books = context.Books.ToList();
                if (seeAllBooks)
                {
                    if (genre != null && genre != "All" && genre != "null")
                    {
                        books = context.Books.Where(x => x.genre == genre).ToList();
                    }
                    else
                    {
                        books = context.Books.ToList();
                    }
                }
                else
                {
                    if (genre != null && genre != "All" && genre != "null")
                    {
                        books = context.Books.Where(x => x.genre == genre && x.isCheckedOut == false).ToList();
                    }
                    else
                    {
                        books = context.Books.Where(x => x.isCheckedOut == false).ToList();
                    }
                }
            }
            
            return View(books);
        }

        //SHOWS ONLY CLIENTS CHECKED OUT BOOKS 
        public ActionResult ViewClientBooks()
        {
            string userID = HttpContext.Request.Cookies["user_id"];
            List<Book> result = null;
            using (libContext context = new libContext())
            {
                result = context.Books.Where(x => x.RenterId == userID).ToList();
            }

            return View(result);
        }

        // GET: LoggedInUserController/Details/5
        public ActionResult Details(int id)
        {
            Book book = null;
            using (libContext context = new libContext())
            {
                book = context.Books.Where(x => x.bookId == id).First();
            }
            return View(book);
        }
 
        public ActionResult Checkout(int id)
        {
            Book book = null;
            using (libContext context = new libContext())
            {
                book = context.Books.Where(x => x.bookId == id).First();
                book.isCheckedOut = true;
                book.RenterId = HttpContext.Request.Cookies["user_id"];
                context.Update(book);
                context.SaveChanges();
            }
            return Redirect("~/LoggedInUser/Index");
        }

        public ActionResult ReturnBook(int id)
        {
            Book book = null;
            using (libContext context = new libContext())
            {
                book = context.Books.Where(x => x.bookId == id).First();
                book.isCheckedOut = false;
                book.RenterId = null;
                context.Update(book);
                context.SaveChanges();
            }
            return Redirect("~/LoggedInUser/Index");
        }

        //Logs User Out
        public ActionResult Logout()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = System.DateTime.Now.AddDays(-1);
            HttpContext.Response.Cookies.Append("user_id", "test", options);
            return Redirect("~/Home/Index");
        }
    }
}
