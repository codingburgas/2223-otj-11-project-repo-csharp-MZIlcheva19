using bsm.bll;
using bsm.util;
using Microsoft.IdentityModel.Tokens;

namespace bsm.console
{
    internal class LoginUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Login User");
            Console.WriteLine();

            string username = InsertUsername();
            string password = InsertPassword();

            if (!UserService.LoginUser(username, password))
            {
                Console.WriteLine();
                Write.LineToCenter("Wrong Username or Password");
                Console.ReadKey();
                Print();
            }

            UserLog.LoggedUser = UserService.GetUserByUsername(username);

            Console.WriteLine();
            Write.LineToCenter("Logged In");
            Console.ReadKey();
            MainMenu.Print();
        }
        private static string InsertUsername()
        {
            Write.ToCenter("Username: ");
            var username = Console.ReadLine();

            if (username.ToUpper() == "B")
            {
                MainMenu.Print();
            }
            if (username.IsNullOrEmpty())
            {
                Console.WriteLine();
                Write.LineToCenter("Username is required");
                Console.ReadKey();
                Print();
            }

            return username;
        }

        private static string InsertPassword()
        {
            Write.ToCenter("Password: ");
            var password = Console.ReadLine();

            if (password.IsNullOrEmpty())
            {
                Console.WriteLine();
                Write.LineToCenter("Password is required");
                Console.ReadKey();
                Print();
            }
            return password;
        }
    }
}
