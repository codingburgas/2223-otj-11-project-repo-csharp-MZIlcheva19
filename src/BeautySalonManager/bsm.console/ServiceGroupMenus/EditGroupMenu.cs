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

            string oldName = InsertOldGroupName();  // Call the InsertOldGroupName() method to get the old group name from the user
            string newName = InsertNewGroupName();  // Call the InsertNewGroupName() method to get the new group name from the user

            ServiceGroupService.EditGroup(oldName, newName);  // Edit the group by replacing the old group name with the new group name

            Console.WriteLine();
            Console.WriteLine("Group Edited");
            ServiceGroupEditMenu.Print();  // Go back to the service group edit menu
        }

        private static string InsertOldGroupName()
        {
            Console.Write("Group Old Name: ");
            string? groupName = Console.ReadLine();  // Read the old group name entered by the user

            switch (ServiceGroupService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine("\nGroup Name is required");  // Display an error message if the old group name is empty
                    Console.ReadKey();
                    Print();  // Call the Print() method again to allow the user to enter the old group name
                    break;
                default: break;  // If the old group name is valid, proceed to the next step
            }

            ServiceGroup serviceGroup = ServiceGroupService.GetGroupByName(groupName);
            if (serviceGroup == null)
            {
                Console.WriteLine("\nGroup doesn't exist");  // Display an error message if the old group name doesn't exist
                Console.ReadKey();
                Print();  // Call the Print() method again to allow the user to enter a different old group name
            }

            return groupName;  // Return the valid old group name entered by the user
        }

        private static string InsertNewGroupName()
        {
            Console.Write("Group Name: ");
            string? groupName = Console.ReadLine();  // Read the new group name entered by the user

            switch (ServiceGroupService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine("\nGroup Name is required");  // Display an error message if the new group name is empty
                    Console.ReadKey();
                    Print();  // Call the Print() method again to allow the user to enter the new group name
                    break;
                case 1:
                    Console.WriteLine("\nGroup Name must not have numbers");  // Display an error message if the new group name contains numbers
                    Console.ReadKey();
                    Print();  // Call the Print() method again to allow the user to enter a different new group name
                    break;
                default: break;  // If the new group name is valid, proceed to the next step
            }

            ServiceGroup serviceGroup = ServiceGroupService.GetGroupByName(groupName);
            if (serviceGroup != null)
            {
                Console.WriteLine("\nGroup already exists");  // Display an error message if the new group name already exists
                Console.ReadKey();
                Print();  // Call the Print() method again to allow the user to enter a different new group name
            }

            return groupName;  // Return the valid new group name entered by the user
        }
    }
}
