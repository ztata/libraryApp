using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libraryApp.Models.Users
{
    public class Client : User
    {
        public int ClientId { get; set; }
        public string CardNumber { get; set; }
        public int BooksCheckedOut { get; set; }
    }
}
