using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using libraryApp.Models.libraryItems;

namespace libraryApp.Models.Users
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public int NumBooksCheckedOut { get; set; }

        public List<Book> BooksCheckedOut { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
