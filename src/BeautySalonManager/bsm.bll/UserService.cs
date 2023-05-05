using Microsoft.Identity.Client;
using System;
using bsm.dal.Models;
using bsm.dal.Data;
using bsm.util;
using System.Security;
using System.Net.NetworkInformation;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using bsm.dal.Repositories;

namespace bsm.bll
{
    public class UserService
    {
        public static bool LoginUser(string username, string password)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                bool verifyUser = false;

                User? user = userRepository.GetUserByUsername(username);

                if (user != null)
                {
                    string saltedPassword = password + user.Salt;
                    string hashedPass = HashPassword(saltedPassword);

                    if (user.Password == hashedPass)
                    {
                        verifyUser = true;
                    }
                }

                return verifyUser;
            }
        }

        public static void RegisterUser(string username, string password, string fName, string lName, string phone, string email)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                User user = new();
                user.Username = username;

                user.Salt = GenerateSalt();
                string saltedPassword = password + user.Salt;
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

        public static void AddAdmin()
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                User? user = userRepository.GetUserByUsername("admin");

                if (user == null)
                {
                    string salt = GenerateSalt();
                    string saltedPassword = "admin" + salt;
                    string hashedPassword = HashPassword(saltedPassword);

                    User admin = new()
                    {
                        Username = "admin",
                        Password = hashedPassword,
                        Salt = salt,
                        FirstName = "admin",
                        LastName = "admin",
                        Phone = "0000000000",
                        Email = "admin@email.com",
                        TypeId = (int)TypeCodes.Admin
                    };

                    userRepository.AddRow(admin);
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
