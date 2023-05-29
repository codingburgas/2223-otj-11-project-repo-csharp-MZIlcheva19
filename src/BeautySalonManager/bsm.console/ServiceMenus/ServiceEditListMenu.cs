using bsm.bll;
using bsm.dal.Models;
using bsm.util;
using Microsoft.IdentityModel.Tokens;

namespace bsm.console
{
    internal class ServiceEditListMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Services");
            Console.WriteLine();

            List<ServiceGroup> serviceGroups = ServiceGroupService.GetAll();

            if(!serviceGroups.IsNullOrEmpty())
            {
                Write.LineToCenter("Service Name");
                foreach (ServiceGroup serviceGroup in serviceGroups)
                {
                    Write.LineToCenter(serviceGroup.Name);
                }
                Console.WriteLine();
            }
            else
            {
                Write.LineToCenter("No Services");
                Console.WriteLine();
            }

            string group = InsertGroupName();
            Console.WriteLine();

            int groupId = ServiceGroupService.GetGroupIdByName(group);

            List<Service> services = ServiceService.GetAllByGroup(groupId).ToList();

            foreach ( Service service in services )
            {
                Write.LineToCenter($"{service.Name} : {service.Price:F2}$ : {service.Time.Hours * 60 + service.Time.Minutes} min");
            }

            Console.WriteLine();
            Write.LineToCenter("[S] See Skills    ");
            Write.LineToCenter("[A] Add Service   ");
            Write.LineToCenter("[E] Edit Service  ");
            Write.LineToCenter("[D] Delete Service");
            Write.LineToCenter("[B] Back          ");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'S': ServiceSkillListMenu.Print(groupId); break;
                    case 'A': AddServiceMenu.Print(groupId); break;
                    case 'E': EditServiceMenu.Print(groupId); break;
                    case 'D': DeleteServiceMenu.Print(groupId); break;
                    case 'B': ServiceGroupEditMenu.Print(); break;
                    default: ServiceGroupEditMenu.Print(); break;
                }
            }
        }

        private static string InsertGroupName()
        {
            Write.ToCenter("Group Name: ");
            string? groupName = Console.ReadLine();

            switch (ServiceGroupService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine();
                    Write.LineToCenter("Group Name is required");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }

            ServiceGroup serviceGroup = ServiceGroupService.GetGroupByName(groupName);
            if (serviceGroup == null)
            {
                Console.WriteLine();
                Write.LineToCenter("Group doesn't exist");
                Console.ReadKey();
                Print();
            }

            return groupName;
        }
    }
}
