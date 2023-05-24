using bsm.bll;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class ServiceListMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Services");
            Console.WriteLine();

            Console.Write("Group Name: ");
            string group = Console.ReadLine();

            int groupId = ServiceGroupService.GetGroupIdByName(group);

            List<Service> services = ServiceService.GetAllByGroup(groupId).ToList();

            foreach (Service service in services)
            {
                Console.WriteLine($"{service.Name} : {service.Price:F2}$ : {service.Time.Hours * 60 + service.Time.Minutes} min");
            }

            Console.WriteLine();
            Console.WriteLine("[A] Make Appointment  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': MakeAppointmentMenu.Print(groupId); break;
                    case 'B': ServiceGroupListMenu.Print(); break;
                    default: ServiceGroupListMenu.Print(); break;
                }
            }
        }
    }
}
