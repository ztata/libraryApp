using libraryApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using libraryApp.Models.Users;
using libraryApp.Models.libraryItems;
using System.Collections.Generic;
using libraryApp.Models.Context;
using libraryApp.Models.HelperClasses;
using System.Linq;

namespace libraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //test cookie
            //HttpContext.Response.Cookies.Append("testCookie", "Hi There");
            return View();
        }

        //Registration methods
        //get
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(IFormCollection collection)
        {
            //create a new client
            Client client = new Client();
            client.FirstName = collection["FirstName"];
            client.LastName = collection["LastName"];
            //SHOULD CHECK HERE TO SEE IF THE EMAIL IS UNIQUE
            client.Email = collection["Email"];
            client.Password = HashPassword.ConvertPasswordToHashedString(collection["Password"]);
            client.NumBooksCheckedOut = 0;
            client.BooksCheckedOut = new List<Book>();
            using (libContext context = new libContext())
            {
                do
                {
                    client.CardNumber = HelperLoginMethods.GenerateUniqueRandomNumbers();
                } while (context.Clients.Where(x => x.CardNumber == client.CardNumber).Count() == 1);

                //save user to db
                context.Clients.Add(client);
                context.SaveChanges();
                client = context.Clients.Where(x => x.Password == client.Password).First();
            }

            //save a registered user cookie
            HttpContext.Response.Cookies.Append("user_id", client.ClientId.ToString());

            //redirect to the loggedinuser index view
            return View("/Views/LoggedInUser/Index");
        }









        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
