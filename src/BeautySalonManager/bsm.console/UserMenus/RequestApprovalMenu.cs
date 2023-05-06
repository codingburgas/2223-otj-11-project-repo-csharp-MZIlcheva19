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
                Console.WriteLine("Are you sure you want to become an employee?  [Y] Yes  [N] No");
            }
            else
            {
                Console.WriteLine("Are you sure you want to remove your employee request?  [Y] Yes  [N] No");
            }

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'Y': UserService.ChangeRequestApproval(UserLog.LoggedUser); OptionsMenu.Print(); break;
                    case 'N': OptionsMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
