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

            Console.Write("[S] Services  [O] Options  ");
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee)
            {
                Console.Write("[K] Skills  [A] Appointments  ");
            }
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin)
            {
                Console.Write("[P] Panel  [A] Appointments  ");
            }
            Console.WriteLine("[E] Exit");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'S': ServiceGroupListMenu.Print(); break;
                    case 'O': OptionsMenu.Print(); break;
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
