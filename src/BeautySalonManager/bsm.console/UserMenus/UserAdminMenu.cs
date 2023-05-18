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
            Console.WriteLine("Employee Requests");
            Console.WriteLine();

            List<User> users = UserService.GetApprovalRequestingUsers();

            foreach(User user in users)
            {
                Console.WriteLine($"{user.Username} {user.FirstName} {user.LastName} {user.Phone} {user.Email}");
            }

            Console.WriteLine();
            Console.WriteLine("[A] Approve User  [B] Back");
            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': ApproveUserMenu.Print(); break;
                    case 'B': OptionsMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
