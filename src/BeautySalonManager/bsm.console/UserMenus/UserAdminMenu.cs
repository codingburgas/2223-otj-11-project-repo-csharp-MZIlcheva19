using bsm.bll;
using bsm.dal.Models;
using bsm.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console.UserMenus
{
    internal class UserAdminMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("[A] Approve User  [R] Remove Employee  [B] Back");
            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': ApproveUserMenu.Print(); break;
                    case 'R': RemoveEmployeeMenu.Print(); break;
                    case 'B': AdminMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
