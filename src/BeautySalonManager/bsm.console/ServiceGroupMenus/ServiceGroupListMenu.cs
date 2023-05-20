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
                Console.WriteLine("No groups added");
            }
            foreach (ServiceGroup serviceGroup in serviceGroups)
            {
                Console.WriteLine($"{serviceGroup.Name}");
            }

            Console.WriteLine();
            Console.WriteLine("[O] Open Group  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'O': ServiceListMenu.Print(); break;
                    case 'B': MainMenu.Print(); break;
                    default: MainMenu.Print(); break;
                }
            }
        }
    }
}
