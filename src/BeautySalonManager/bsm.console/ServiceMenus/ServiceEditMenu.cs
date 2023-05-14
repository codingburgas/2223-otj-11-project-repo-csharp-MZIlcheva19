using bsm.bll;
using bsm.console.BaseMenus;
using bsm.dal.Models;
using bsm.util;
using Microsoft.IdentityModel.Tokens;

namespace bsm.console.ServiceMenus
{
    internal class ServiceEditMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Service Groups");
            Console.WriteLine();

            List<ServiceGroup> serviceGroups = ServiceGroupService.GetAll();

            if(serviceGroups.IsNullOrEmpty())
            {
                Console.WriteLine("No groups added");
            }
            foreach (ServiceGroup serviceGroup in serviceGroups)
            {
                Console.WriteLine($"{serviceGroup}");
            }

            Console.WriteLine();
            Console.WriteLine("[A] Add Group  [D] Delete Group  [E] Edit Group  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': break;
                    case 'D': break;
                    case 'E': break;
                    case 'B': AdminMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
