using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class MainMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();

            Console.Write("[O] Open Services  [S] Settings  ");
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee)
            {
                Console.Write("[K] Skills  [A] Appointments  ");
            }
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin)
            {
                Console.Write("[P] Admin Panel  [A] Appointments  ");
            }
            Console.WriteLine("[E] Exit");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'O': ServiceGroupListMenu.Print(); break;
                    case 'S': OptionsMenu.Print(); break;
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
