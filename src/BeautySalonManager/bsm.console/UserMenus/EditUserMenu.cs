using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class EditUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Edit User");
            Console.WriteLine();

            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();
            string phone = Console.ReadLine();
            string email = Console.ReadLine();

            UserService.EditUser(UserLog.LoggedUser, username, password, fName, lName, phone, email);

            Console.WriteLine();
            Console.WriteLine("User Edited");
            Console.ReadKey();
            OptionsMenu.Print();
        }
    }
}
