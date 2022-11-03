using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using libraryApp.Models.Users;
using libraryApp.Models.Context;

namespace libraryApp.Models.HelperClasses
{
    public static class HashPassword
    {
        public static string ConvertPasswordToHashedString(string password)
        {
            //creating salt value
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //getting hash value
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            //combine salt and password bytes
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //turn the combined salt and hash into a string for storage
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            //return the hashed and salted string
            return savedPasswordHash;

        }

        
        //PULL SOME OF THE MEAT OF THESE OUT INTO ANOTHER METHOD SO WE DONT
        //REPEAT IT FOR BOTH CLIENT AND EMPLOYEE
        
        public static bool CompareHashedClientPasswords(string email, string enteredPassword)
        {
            Client client = null;
            using (libContext context = new libContext())
            {
                //NEED TO HANDLE EXCEPTION HERE IF THE USER DOES NOT EXIST IN THE DATABASE
                client = context.Clients.Where(x => x.Email == email).First();
            }

            if (client != null)
            {
                //retrieve stored value 
                string savedPasswordHash = client.Password;

                //extract the bytes
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

                //get the salt
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                //get the hash of the user entered password
                var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);

                //compare the results
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CompareHashedEmployeePasswords(string email, string enteredPassword)
        {
            Employee employee = null;
            using (libContext context = new libContext())
            {
                //NEED TO HANDLE EXCEPTION HERE IF THE USER DOES NOT EXIST IN THE DATABASE
                employee = context.Employees.Where(x => x.Email == email).First();
            }

            if (employee != null)
            {
                //retrieve stored value 
                string savedPasswordHash = employee.Password;

                //extract the bytes
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

                //get the salt
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                //get the hash of the user entered password
                var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);

                //compare the results
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
