using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace libraryApp.Models.libraryItems
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string author { get; set; }

        [Required]
        public int pageCount { get; set; }

        [Required]
        public bool isCheckedOut { get; set; }

        //public string isbnNumber { get; set; }

        public string summary { get; set; }

    }
}
