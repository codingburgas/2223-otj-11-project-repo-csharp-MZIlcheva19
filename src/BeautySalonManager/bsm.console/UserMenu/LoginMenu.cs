using bsm.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console.UserMenu
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

            Console.WriteLine();
            Console.WriteLine("Logged In");
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
