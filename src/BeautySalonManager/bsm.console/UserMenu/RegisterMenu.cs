using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bsm.bll;

namespace bsm.console.UserMenu
{
    public class RegisterMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("Register User");
            Console.WriteLine();

            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();
            string phone = Console.ReadLine();
            string email = Console.ReadLine();

            UserService.RegisterUser(username, password, fName, lName, phone, email);

            Console.WriteLine();
            Console.WriteLine("User registered");
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
