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

            string group = Console.ReadLine();

            int groupId = ServiceGroupService.GetGroupIdByName(group);

            List<Service> services = ServiceService.GetAllByGroup(groupId).ToList();

            foreach ( Service service in services )
            {
                Console.WriteLine($"{service.Name} : {service.Price} : {service.Time.ToString("g")}");
            }

            Console.WriteLine();
            Console.WriteLine("[A] Add Service  [E] Edit Service  [D] Delete Service  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': AddServiceMenu.Print(groupId); break;
                    case 'E': break;
                    case 'D': break;
                    case 'B': ServiceGroupEditMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
