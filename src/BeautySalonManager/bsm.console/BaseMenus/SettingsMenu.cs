using bsm.util;
using System.Text;

namespace bsm.console
{
    internal class SettingsMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Settings");
            Console.WriteLine();

            if(UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin)
            {
                Write.LineToCenter("[E] EditUser             ");
                Write.LineToCenter("[D] DeleteUser           ");
            }
            if(UserLog.LoggedUser.TypeId == (int)TypeCodes.Client)
            {
                if (UserLog.LoggedUser.EmployeeRequest == true)
                {
                    Write.LineToCenter("[R] RemoveEmployeeRequest");
                }
                else
                {
                    Write.LineToCenter("[R] RequestEmployee      ");
                }
            }
            Write.LineToCenter("[L] LogOut               ");
            Write.LineToCenter("[B] Back                 ");

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
