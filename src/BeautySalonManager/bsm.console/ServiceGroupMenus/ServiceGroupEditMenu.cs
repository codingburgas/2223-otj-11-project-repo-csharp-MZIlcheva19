using bsm.bll;
using bsm.dal.Models;
using Microsoft.IdentityModel.Tokens;

namespace bsm.console
{
    internal class ServiceGroupEditMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Service Groups");
            Console.WriteLine();

            List<ServiceGroup> serviceGroups = ServiceGroupService.GetAll();

            if (serviceGroups.IsNullOrEmpty())
            {
                Console.WriteLine("No groups added");  // Display a message if no groups have been added
            }
            foreach (ServiceGroup serviceGroup in serviceGroups)
            {
                Console.WriteLine($"{serviceGroup.Name}");  // Display the names of the existing service groups
            }

            Console.WriteLine();
            Console.WriteLine("[O] Open Group  [A] Add Group  [D] Delete Group  [E] Edit Group  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'O': ServiceEditListMenu.Print(); break;  // Call the ServiceEditListMenu.Print() method to open the selected group
                    case 'A': AddGroupMenu.Print(); break;  // Call the AddGroupMenu.Print() method to add a new group
                    case 'D': DeleteGroupMenu.Print(); break;  // Call the DeleteGroupMenu.Print() method to delete a group
                    case 'E': EditGroupMenu.Print(); break;  // Call the EditGroupMenu.Print() method to edit a group
                    case 'B': AdminMenu.Print(); break;  // Go back to the admin menu
                    default: break;
                }
            }
        }
    }
}
