using bsm.bll;
using bsm.dal.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console.UserMenus
{
    internal class ApproveUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Aprrove User");
            Console.WriteLine();

            List<User> users = UserService.GetApprovalRequestingUsers();

            if(!users.IsNullOrEmpty())
            {
                Console.WriteLine("Username FirstName LastName Phone Email");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Username} {u.FirstName} {u.LastName} {u.Phone} {u.Email}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No employee requests");
                Console.WriteLine();
            }

            Console.Write("Username: ");
            string username = Console.ReadLine();

            User user = UserService.GetUserByUsername(username);
            UserService.MakeEmployee(user);
            

            Console.WriteLine();
            Console.WriteLine("Employee Added");
            UserAdminMenu.Print();
        }
    }
}
