using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class LoginUserMenu
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
