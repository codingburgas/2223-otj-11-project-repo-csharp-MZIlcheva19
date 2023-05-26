using bsm.bll;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class DeleteGroupMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Delete Group");
            Console.WriteLine();

            string name = InsertGroupName();

            ServiceGroupService.DeleteGroup(name);

            Console.WriteLine();
            Console.WriteLine("Group Deleted");
            Console.ReadKey();
            ServiceGroupEditMenu.Print();
        }

        private static string InsertGroupName()
        {
            Console.Write($"Group Name: ");
            string? groupName = Console.ReadLine();

            switch (ServiceGroupService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine($"\nGroup Name is required");
                    Console.ReadKey();
                    Print();
                    break;
                case 1:
                    Console.WriteLine($"\nGroup Name must not have numbers");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }

            ServiceGroup serviceGroup = ServiceGroupService.GetGroupByName(groupName);
            if(serviceGroup == null)
            {
                Console.WriteLine($"\nGroup doesn't exist");
                Console.ReadKey();
                Print();
            }

            return groupName;
        }
    }
}
