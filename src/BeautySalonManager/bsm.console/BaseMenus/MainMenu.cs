using bsm.bll;
using bsm.util;
using System.Text;

namespace bsm.console
{
    internal class MainMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();
            Write.LineToCenter("Main Menu");
            Console.WriteLine();
            Write.LineToCenter("[O] Open Services ");
            Write.LineToCenter("[S] Settings     ");
            
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee)
            {
                Write.LineToCenter("[K] Skills       ");
                Write.LineToCenter("[A] Appointments ");
            }
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin)
            {
                Write.LineToCenter("[P] Admin Panel  ");
                Write.LineToCenter("[A] Appointments ");
            }
            Write.LineToCenter("[E] Exit         ");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'O': ServiceGroupListMenu.Print(); break;
                    case 'S': SettingsMenu.Print(); break;
                    case 'K': if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee) EmployeeSkillsMenu.Print(); break;
                    case 'A': if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin || UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee) AppointmetListMenu.Print(); break;
                    case 'P': if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin) AdminMenu.Print(); break;
                    case 'E': Environment.Exit(0); break;
                    default: break;
                }
            }
        }
    }
}
