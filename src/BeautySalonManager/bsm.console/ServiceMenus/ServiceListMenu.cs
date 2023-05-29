using bsm.bll;
using bsm.dal.Models;
using bsm.util;
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
            Write.LineToCenter("Services");
            Console.WriteLine();

            string group = InsertGroupName();

            int groupId = ServiceGroupService.GetGroupIdByName(group);

            List<Service> services = ServiceService.GetAllByGroup(groupId).ToList();

            foreach (Service service in services)
            {
                Write.LineToCenter($"{service.Name} : {service.Price:F2}$ : {service.Time.Hours * 60 + service.Time.Minutes} min");
            }

            Console.WriteLine();
            Write.LineToCenter("[A] Make Appointment");
            Write.LineToCenter("[B] Back            ");

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
