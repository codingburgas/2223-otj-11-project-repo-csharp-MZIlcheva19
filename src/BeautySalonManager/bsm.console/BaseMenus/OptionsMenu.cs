using bsm.util;

namespace bsm.console
{
    internal class OptionsMenu
    {
        public static void Print()
        {
            Console.Clear();
            if(UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin)
            {
                Console.Write("[E] EditUser  [D] DeleteUser  ");
            }
            Console.Write("[L] LogOut  ");
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin)
            {
                Console.Write("[A] ApproveUser  ");
            }
            Console.WriteLine("[B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'E': if(UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) Console.WriteLine("Edit User"); break;
                    case 'D': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) DeleteUserMenu.Print(); break;
                    case 'L': UserLog.LoggedUser = null; StartMenu.Print(); break;
                    case 'A': if(UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin) Console.WriteLine("User Approval list"); break;
                    case 'B': MainMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
