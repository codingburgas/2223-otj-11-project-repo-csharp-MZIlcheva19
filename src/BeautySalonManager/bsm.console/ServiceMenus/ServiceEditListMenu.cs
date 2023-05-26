using bsm.bll;
using bsm.dal.Models;
using Microsoft.IdentityModel.Tokens;

namespace bsm.console
{
    internal class ServiceEditListMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Services");
            Console.WriteLine();

            List<ServiceGroup> serviceGroups = ServiceGroupService.GetAll();

            if(!serviceGroups.IsNullOrEmpty())
            {
                Console.WriteLine("Service Name");
                foreach (ServiceGroup serviceGroup in serviceGroups)
                {
                    Console.WriteLine(serviceGroup.Name);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Services");
                Console.WriteLine();
            }

            string group = InsertGroupName();
            Console.WriteLine();

            int groupId = ServiceGroupService.GetGroupIdByName(group);

            List<Service> services = ServiceService.GetAllByGroup(groupId).ToList();

            foreach ( Service service in services )
            {
                Console.WriteLine($"{service.Name} : {service.Price:F2}$ : {service.Time.Hours * 60 + service.Time.Minutes} min");
            }

            Console.WriteLine();
            Console.WriteLine("[S] See Skills  [A] Add Service  [E] Edit Service  [D] Delete Service  [B] Back");

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
            Console.Write("Group Name: ");
            string? groupName = Console.ReadLine();

            switch (ServiceGroupService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine("\nGroup Name is required");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }

            ServiceGroup serviceGroup = ServiceGroupService.GetGroupByName(groupName);
            if (serviceGroup == null)
            {
                Console.WriteLine("\nGroup doesn't exist");
                Console.ReadKey();
                Print();
            }

            return groupName;
        }
    }
}
