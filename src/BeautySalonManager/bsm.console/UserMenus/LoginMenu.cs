using bsm.bll;
using bsm.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class LoginMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Login User");
            Console.WriteLine();

            string username = Console.ReadLine();
            string password = Console.ReadLine();

            if (!UserService.LoginUser(username, password))
            {
                Console.WriteLine();
                Console.WriteLine("Wrong Username or Password");
                Console.ReadKey();
                Print();
            }

            UserLog.LoggedUser = UserService.GetUserByUsername(username);

            Console.WriteLine();
            Console.WriteLine("Logged In");
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
