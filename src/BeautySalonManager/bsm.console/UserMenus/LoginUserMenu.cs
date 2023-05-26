using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class LoginUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine($"{"Login User", 20}");
            Console.WriteLine();

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
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
