using bsm.util;

namespace bsm.console
{
    internal class OptionsMenu
    {
        public static void Print()
        {
            Console.Clear();

            if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin)
            {
                Console.Write("[E] EditUser  [D] DeleteUser  ");  // If the logged-in user is not an admin, display options for editing and deleting user
            }

            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Client)
            {
                if (UserLog.LoggedUser.EmployeeRequest == true)
                {
                    Console.Write("[R] RemoveEmployeeRequest  ");  // If the logged-in user is a client and has requested an employee, display option to remove the employee request
                }
                else
                {
                    Console.Write("[R] RequestEmployee  ");  // If the logged-in user is a client and has not requested an employee, display option to request an employee
                }
            }

            Console.WriteLine("[L] LogOut  [B] Back");  // Display options for logging out and going back

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);  // Read a key from the console and convert it to uppercase

                switch (input)
                {
                    case 'E': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) EditUserMenu.Print(); break;  // If the input is 'E' and the user is not an admin, invoke the Print() method of EditUserMenu
                    case 'D': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) DeleteUserMenu.Print(); break;  // If the input is 'D' and the user is not an admin, invoke the Print() method of DeleteUserMenu
                    case 'R': if (UserLog.LoggedUser.TypeId != (int)TypeCodes.Admin) RequestApprovalMenu.Print(); break;  // If the input is 'R' and the user is not an admin, invoke the Print() method of RequestApprovalMenu
                    case 'L': UserLog.LoggedUser = null; StartMenu.Print(); break;  // If the input is 'L', log out the user and invoke the Print() method of StartMenu
                    case 'B': MainMenu.Print(); break;  // If the input is 'B', go back to the main menu by invoking the Print() method of MainMenu
                    default: break;  // If the input doesn't match any of the cases, do nothing and continue the loop
                }
            }
        }
    }
}
