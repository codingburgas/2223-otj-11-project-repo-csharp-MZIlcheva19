using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class RegisterUserMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("Register User");
            Console.WriteLine();

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("First Name: ");
            string fName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lName = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            UserService.RegisterUser(username, password, fName, lName, phone, email);

            UserLog.LoggedUser = UserService.GetUserByUsername(username);

            Console.WriteLine();
            Console.WriteLine("User registered");
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
