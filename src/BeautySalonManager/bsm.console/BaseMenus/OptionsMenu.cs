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
            if(UserLog.LoggedUser.EmployeeRequest == true)
            {
                Console.Write("[R] RemoveEmployeeRequest  ");
            }
            else
            {
                Console.Write("[R] RequestEmployee  ");
            }
            Console.WriteLine("[L] LogOut  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'E': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) EditUserMenu.Print(); break;
                    case 'D': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) DeleteUserMenu.Print(); break;
                    case 'R': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) RequestApprovalMenu.Print(); break;
                    case 'L': UserLog.LoggedUser = null; StartMenu.Print(); break;
                    case 'B': MainMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
