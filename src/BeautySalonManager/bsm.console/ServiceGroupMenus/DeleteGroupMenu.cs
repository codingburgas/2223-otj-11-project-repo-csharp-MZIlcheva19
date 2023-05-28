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

            string name = InsertGroupName();  // Call the InsertGroupName() method to get the group name from the user

            ServiceGroupService.DeleteGroup(name);  // Delete the group with the specified name

            Console.WriteLine();
            Console.WriteLine("Group Deleted");
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
            if (serviceGroup == null)
            {
                Console.WriteLine("\nGroup doesn't exist");  // Display an error message if the group name doesn't exist
                Console.ReadKey();
                Print();  // Call the Print() method again to allow the user to enter a different group name
            }

            return groupName;  // Return the valid group name entered by the user
        }
    }
}
