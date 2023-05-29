using bsm.bll;
using bsm.dal.Models;
using bsm.util;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class RemoveEmployeeMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Remove Employee");
            Console.WriteLine();

            List<User> users = UserService.GetEmployees();

            if(!users.IsNullOrEmpty())
            {
                Write.LineToCenter("Username : FirstName : LastName : Phone : Email");
                foreach (User u in users)
                {
                    Write.LineToCenter($"{u.Username} {u.FirstName} {u.LastName} {u.Phone} {u.Email}");
                }
                Console.WriteLine();
            }
            else
            {
                Write.LineToCenter("No employees");
                Console.WriteLine();
            }

            string username = InsertUsername();

            User user = UserService.GetUserByUsername(username);
            UserService.MakeClient(user);


            Console.WriteLine();
            Write.LineToCenter("Employee Removed");
            UserAdminMenu.Print();
        }
        private static string InsertUsername()
        {
            Write.ToCenter("Username: ");
            string? username = Console.ReadLine();

            if (username.ToUpper() == "B")
            {
                MainMenu.Print();
            }

            if (username.IsNullOrEmpty())
            {
                Console.WriteLine();
                Write.LineToCenter("Username is required");
                Console.ReadKey();
                Print();
            }

            List<User> usersList = UserService.GetEmployees();
            User user = UserService.GetUserByUsername(username);
            if (!usersList.Exists(u => u == user))
            {
                Console.WriteLine();
                Write.LineToCenter("User doesn't exist");
                Console.ReadKey();
                Print();
            }

            return username;
        }
    }
}
