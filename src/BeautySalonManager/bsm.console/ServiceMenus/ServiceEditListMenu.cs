using bsm.bll;
using bsm.dal.Models;

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

            foreach (ServiceGroup serviceGroup in serviceGroups)
            { 
                Console.WriteLine(serviceGroup.Name);
            }
            Console.WriteLine();

            Console.Write("Insert group name: ");
            string group = Console.ReadLine(); 
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
    }
}
