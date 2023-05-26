using bsm.bll;
using bsm.dal.Models;

namespace bsm.console
{
    internal class AddGroupMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Add Group");
            Console.WriteLine();

            string name = InsertGroupName();

            ServiceGroupService.AddGroup(name);

            Console.WriteLine();
            Console.WriteLine("Group Added");
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
