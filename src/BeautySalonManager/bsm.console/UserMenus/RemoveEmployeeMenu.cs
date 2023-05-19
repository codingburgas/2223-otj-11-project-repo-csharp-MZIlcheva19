using bsm.bll;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console.UserMenus
{
    internal class RemoveEmployeeMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Remove Employee");
            Console.WriteLine();

            List<User> users = UserService.GetEmployees();

            foreach (User u in users)
            {
                Console.WriteLine($"{u.Username} {u.FirstName} {u.LastName} {u.Phone} {u.Email}");
            }
            Console.WriteLine();

            string username = Console.ReadLine();

            User user = UserService.GetUserByUsername(username);
            UserService.MakeClient(user);


            Console.WriteLine();
            Console.WriteLine("Employee Removed");
            UserAdminMenu.Print();
        }
    }
}
