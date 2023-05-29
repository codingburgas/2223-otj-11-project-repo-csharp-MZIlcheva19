using bsm.bll;
using bsm.dal.Models;
using bsm.util;
using Microsoft.IdentityModel.Tokens;

namespace bsm.console
{
    internal class ServiceGroupEditMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Service Groups");
            Console.WriteLine();

            List<ServiceGroup> serviceGroups = ServiceGroupService.GetAll();

            if(serviceGroups.IsNullOrEmpty())
            {
                Write.LineToCenter("No groups added");
            }
            foreach (ServiceGroup serviceGroup in serviceGroups)
            {
                Write.LineToCenter($"{serviceGroup.Name}");
            }

            Console.WriteLine();
            Write.LineToCenter("[O] Open Group  ");
            Write.LineToCenter("[A] Add Group   ");
            Write.LineToCenter("[D] Delete Group");
            Write.LineToCenter("[E] Edit Group  ");
            Write.LineToCenter("[B] Back        ");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'O': ServiceEditListMenu.Print(); break;
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
