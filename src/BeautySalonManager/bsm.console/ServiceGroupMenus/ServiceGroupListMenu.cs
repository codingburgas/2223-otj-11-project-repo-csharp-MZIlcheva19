using bsm.bll;
using bsm.dal.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class ServiceGroupListMenu
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
            Console.WriteLine("[O] Open Group  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'O': ServiceListMenu.Print(); break;  // Call the ServiceListMenu.Print() method to open the selected group
                    case 'B': MainMenu.Print(); break;  // Go back to the main menu
                    default: MainMenu.Print(); break;  // Go back to the main menu if an invalid input is provided
                }
            }
        }
    }
}
