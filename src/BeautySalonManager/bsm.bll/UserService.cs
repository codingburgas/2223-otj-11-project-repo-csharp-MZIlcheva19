using bsm.dal.Data;
using bsm.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using bsm.dal.Models;
using bsm.util;

namespace bsm.bll
{
    public class UserService
    {
        public static void RegisterUser(string username, string password, string fName, string lName, string phone, string email)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                User user = new();
                user.Username = username;

                user.Salt = GenerateSalt();
                string saltedPassword = user.Password + user.Salt;
                user.Password = HashPassword(saltedPassword);

                user.FirstName = fName;
                user.LastName = lName;
                user.Phone = phone;
                user.Email = email;
                user.TypeId = (int)TypeCodes.Client;

                if(user != null)
                {
                    userRepository.AddRow(user);
                }
            }
        }

        public static string GenerateSalt()
        {
            Random rnd = new Random();

            byte[] rndBytes = new byte[16];
            rnd.NextBytes(rndBytes);

            string salt = Convert.ToHexString(rndBytes);

            return salt;
        }

        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            byte[] passBytes = Encoding.Default.GetBytes(password);

            string hashedPass = Convert.ToHexString(hash.ComputeHash(passBytes));

            return hashedPass;
        }
    }
}
