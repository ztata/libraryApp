using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace libraryApp.Models.Users
{
    public class Employee : User
    {
        [Key]
        public int EmployeeId { get; set; }
    }
}
