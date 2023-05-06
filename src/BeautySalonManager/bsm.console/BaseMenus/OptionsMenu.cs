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
                Console.Write("[E] EditUser  [D] DeleteUser  [R] RequestApproval  ");
            }
            Console.Write("[L] LogOut  ");
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin)
            {
                Console.Write("[A] ApproveUsers  ");
            }
            Console.WriteLine("[B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'E': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) EditUserMenu.Print(); break;
                    case 'D': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) DeleteUserMenu.Print(); break;
                    case 'R': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) Console.WriteLine("Request Employee Approval"); break;
                    case 'L': UserLog.LoggedUser = null; StartMenu.Print(); break;
                    case 'A': if(UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin) Console.WriteLine("User Approval list"); break;
                    case 'B': MainMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
