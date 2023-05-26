using bsm.bll;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class EditGroupMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Edit Group");
            Console.WriteLine();

            string oldName = InsertOldGroupName();
            string newName = InsertNewGroupName();

            ServiceGroupService.EditGroup(oldName, newName);

            Console.WriteLine();
            Console.WriteLine("Group Edited");
            ServiceGroupEditMenu.Print();
        }

        private static string InsertOldGroupName()
        {
            Console.Write($"Group Old Name: ");
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
            if (serviceGroup == null)
            {
                Console.WriteLine($"\nGroup doesn't exist");
                Console.ReadKey();
                Print();
            }

            return groupName;
        }
        private static string InsertNewGroupName()
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
            if (serviceGroup != null)
            {
                Console.WriteLine($"\nGroup already exists");
                Console.ReadKey();
                Print();
            }

            return groupName;
        }
    }
}
