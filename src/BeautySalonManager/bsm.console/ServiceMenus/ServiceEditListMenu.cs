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

            Console.Write("Insert group name: ");
            string group = Console.ReadLine();

            int groupId = ServiceGroupService.GetGroupIdByName(group);

            List<Service> services = ServiceService.GetAllByGroup(groupId).ToList();

            foreach ( Service service in services )
            {
                Console.WriteLine($"{service.Name} : {service.Price:F2}$ : {service.Time.ToString("mm")} min");
            }

            Console.WriteLine();
            Console.WriteLine("[A] Add Service  [E] Edit Service  [D] Delete Service  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': AddServiceMenu.Print(groupId); break;
                    case 'E': EditServiceMenu.Print(groupId); break;
                    case 'D': DeleteServiceMenu.Print(groupId); break;
                    case 'B': ServiceGroupEditMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
