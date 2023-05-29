using bsm.bll;
using bsm.dal.Models;
using bsm.util;

namespace bsm.console
{
    internal class AddGroupMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Add Group");
            Console.WriteLine();

            string name = InsertGroupName();

            ServiceGroupService.AddGroup(name);

            Console.WriteLine();
            Write.LineToCenter("Group Added");
            Console.ReadKey();
            ServiceGroupEditMenu.Print();
        }

        private static string InsertGroupName()
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
