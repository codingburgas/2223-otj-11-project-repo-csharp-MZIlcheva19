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

            if(serviceGroups.IsNullOrEmpty())
            {
                Console.WriteLine("No groups added");
            }
            foreach (ServiceGroup serviceGroup in serviceGroups)
            {
                Console.WriteLine($"{serviceGroup.Name}");
            }

            Console.WriteLine();
            Console.WriteLine("[O] Open Group  [A] Add Group  [D] Delete Group  [E] Edit Group  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'O': ServiceEditListMenu.PrintAdmin(); break;
                    case 'A': AddGroupMenu.Print(); break;
                    case 'D': DeleteGroupMenu.Print(); break;
                    case 'E': EditGroupMenu.Print(); break;
                    case 'B': AdminMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
