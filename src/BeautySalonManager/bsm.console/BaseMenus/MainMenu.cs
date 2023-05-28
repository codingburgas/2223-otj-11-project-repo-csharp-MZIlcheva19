using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class MainMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();  // Add admin user if not already added

            Console.Write("[O] Open Services  [S] Settings  ");  // Display options for opening services and settings
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee)  // Check if the logged-in user is an employee
            {
                Console.Write("[K] Skills  [A] Appointments  ");  // Display options for skills and appointments
            }
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin)  // Check if the logged-in user is an admin
            {
                Console.Write("[P] Admin Panel  [A] Appointments  ");  // Display options for admin panel and appointments
            }
            Console.WriteLine("[E] Exit");  // Display option for exiting the program

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);  // Read a key from the console and convert it to uppercase

                switch (input)
                {
                    case 'O': ServiceGroupListMenu.Print(); break;  // If the input is 'O', invoke the Print() method of ServiceGroupListMenu
                    case 'S': OptionsMenu.Print(); break;  // If the input is 'S', invoke the Print() method of OptionsMenu
                    case 'K': if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee) EmployeeSkillsMenu.Print(); break;  // If the input is 'K' and the user is an employee, invoke the Print() method of EmployeeSkillsMenu
                    case 'A': if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin || UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee) AppointmetListMenu.Print(); break;  // If the input is 'A' and the user is an admin or employee, invoke the Print() method of AppointmetListMenu
                    case 'P': if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin) AdminMenu.Print(); break;  // If the input is 'P' and the user is an admin, invoke the Print() method of AdminMenu
                    case 'E': Environment.Exit(0); break;  // If the input is 'E', exit the program
                    default: break;  // If the input doesn't match any of the cases, do nothing and continue the loop
                }
            }
        }
    }
}
