using bsm.bll;
using bsm.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class RequestApprovalMenu
    {
        public static void Print()
        {
            Console.Clear();
            if(UserLog.LoggedUser.EmployeeRequest == false)
            {
                Write.LineToCenter("Are you sure you want to become an employee?");
                Write.LineToCenter("[Y] Yes");
                Write.LineToCenter("[N] No ");
            }
            else
            {
                Write.LineToCenter("Are you sure you want to remove your employee request?");
                Write.LineToCenter("[Y] Yes");
                Write.LineToCenter("[N] No ");
            }

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'Y': UserService.ChangeRequestApproval(UserLog.LoggedUser); SettingsMenu.Print(); break;
                    case 'N': SettingsMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
