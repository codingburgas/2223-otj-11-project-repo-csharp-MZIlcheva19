using bsm.bll;
using bsm.dal.Models;
using bsm.util;
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
            Write.LineToCenter("Service Groups");
            Console.WriteLine();

            List<ServiceGroup> serviceGroups = ServiceGroupService.GetAll();

            if (serviceGroups.IsNullOrEmpty())
            {
                Write.LineToCenter("No groups added");
            }
            foreach (ServiceGroup serviceGroup in serviceGroups)
            {
                Write.LineToCenter($"{serviceGroup.Name}");
            }

            Console.WriteLine();
            Write.LineToCenter("[O] Open Group");
            Write.LineToCenter("[B] Back      ");

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
