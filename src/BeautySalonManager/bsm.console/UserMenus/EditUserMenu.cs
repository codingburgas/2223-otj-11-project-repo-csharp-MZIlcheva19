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

            UserService.EditUser(UserLog.LoggedUser, username, password, fName, lName, phone, email);

            Console.WriteLine();
            Console.WriteLine("User Edited");
            Console.ReadKey();
            OptionsMenu.Print();
        }
    }
}
