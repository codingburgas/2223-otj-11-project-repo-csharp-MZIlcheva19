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

            string name = InsertGroupName();  // Call the InsertGroupName() method to get the group name from the user

            ServiceGroupService.AddGroup(name);  // Add the group to the service group list

            Console.WriteLine();
            Console.WriteLine("Group Added");
            Console.ReadKey();
            ServiceGroupEditMenu.Print();  // Go back to the service group edit menu
        }

        private static string InsertGroupName()
        {
            Console.Write("Group Name: ");
            string? groupName = Console.ReadLine();  // Read the group name entered by the user

            switch (ServiceGroupService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine("\nGroup Name is required");  // Display an error message if the group name is empty
                    Console.ReadKey();
                    Print();  // Call the Print() method again to allow the user to enter the group name
                    break;
                case 1:
                    Console.WriteLine("\nGroup Name must not have numbers");  // Display an error message if the group name contains numbers
                    Console.ReadKey();
                    Print();  // Call the Print() method again to allow the user to enter the group name
                    break;
                default: break;  // If the group name is valid, proceed to the next step
            }

            ServiceGroup serviceGroup = ServiceGroupService.GetGroupByName(groupName);
            if (serviceGroup != null)
            {
                Console.WriteLine("\nGroup already exists");  // Display an error message if the group name already exists
                Console.ReadKey();
                Print();  // Call the Print() method again to allow the user to enter a different group name
            }

            return groupName;  // Return the valid group name entered by the user
        }
    }
}
