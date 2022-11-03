using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libraryApp.Models.Users;
using libraryApp.Models.Context;

namespace libraryApp.Models.HelperClasses
{
    public static class HelperLoginMethods
    {
        public static bool CheckIfClientEmailExists(string email)
        {
            Client client = null;
            using (libContext context = new libContext())
            {
                try
                {
                    client = context.Clients.Where(x => x.Email == email).First();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool CheckIfEmployeeEmailExists(string email)
        {
            Employee employee = null;
            using (libContext context = new libContext())
            {
                try
                {
                    employee = context.Employees.Where(x => x.Email == email).First();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static string GenerateUniqueRandomNumbers()
        {
            Random generator = new Random();
            string r = generator.Next(0, 1000000).ToString("D6");
            return r;
        }
    }
}
