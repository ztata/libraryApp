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


    // NEED TO INCLUDE SOME METHODS HERE WHERE YOU CAN SEE WHAT BOOKS ARE CHECK OUT BY YOU 


    {
        // GET: LoggedInUserController
        public ActionResult Index(bool seeAllBooks = false)
        {
            List<Book> books = null;
            if (seeAllBooks)
            {
                using (libContext context = new libContext())
                {
                    books = context.Books.ToList();
                }
            }
            else
            {
                using (libContext context = new libContext())
                {
                    books = context.Books.Where(x => x.isCheckedOut == false).ToList();
                }
            }
            return View(books);
        }

        // GET: LoggedInUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoggedInUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoggedInUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //make this into the view book details page
        // GET: LoggedInUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //make this into the check out the book button 
        // POST: LoggedInUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //make this into a return the book early method 
        // GET: LoggedInUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //make this into a delet the book early method 
        // POST: LoggedInUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
