using bsm.bll;
using bsm.dal.Models;
using bsm.util;
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
            Write.LineToCenter("Edit Group");
            Console.WriteLine();

            string oldName = InsertOldGroupName();
            string newName = InsertNewGroupName();

            ServiceGroupService.EditGroup(oldName, newName);

            Console.WriteLine();
            Write.LineToCenter("Group Edited");
            ServiceGroupEditMenu.Print();
        }

        private static string InsertOldGroupName()
        {
            Write.ToCenter("Group Old Name: ");
            string? groupName = Console.ReadLine();

            switch (ServiceGroupService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine();
                    Write.LineToCenter("Group Name is required");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }

            ServiceGroup serviceGroup = ServiceGroupService.GetGroupByName(groupName);
            if (serviceGroup == null)
            {
                Console.WriteLine();
                Write.LineToCenter("Group doesn't exist");
                Console.ReadKey();
                Print();
            }

            return groupName;
        }

        private static string InsertNewGroupName()
        {
            Write.ToCenter("Group Name: ");
            string? groupName = Console.ReadLine();

            switch (ServiceGroupService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine();
                    Write.LineToCenter("Group Name is required");
                    Console.ReadKey();
                    Print();
                    break;
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Group Name must not have numbers");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }

            ServiceGroup serviceGroup = ServiceGroupService.GetGroupByName(groupName);
            if (serviceGroup != null)
            {
                Console.WriteLine();
                Write.LineToCenter("Group already exists");
                Console.ReadKey();
                Print();
            }

            return groupName;
        }
    }
}
