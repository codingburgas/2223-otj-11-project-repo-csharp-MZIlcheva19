using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class DeleteUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to delete your account?  [Y] Yes  [N] No");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'Y': UserService.DeleteUser(UserLog.LoggedUser); StartMenu.Print(); break;
                    case 'N': OptionsMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
