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
    internal class ServiceSkillListMenu
    {
        public static void Print(int groupId)
        {
            Console.Clear();
            Write.LineToCenter("See Skills");
            Console.WriteLine();

            List<Service> services = ServiceService.GetAllByGroup(groupId);

            Write.LineToCenter("Services\n");
            foreach (Service item in services)
            {
                Write.LineToCenter(item.Name);
            }

            string serviceName = InsertServiceName(groupId);
            Console.WriteLine();

            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            List<Skill> skills = SkillService.GetServicesSkills(service.Id);

            foreach (Skill skill in skills)
            {
                Write.LineToCenter(skill.Name);
            }

            Console.WriteLine();
            Write.LineToCenter("[A] Add Skills  ");
            Write.LineToCenter("[R] Remove Skill");
            Write.LineToCenter("[B] Back        ");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': AddServiceSkillMenu.Print(service); break;
                    case 'R': RemoveServiceSkillMenu.Print(service); break;
                    case 'B': ServiceEditListMenu.Print(); break;
                    default: ServiceEditListMenu.Print(); break;
                }
            }
        }

        private static string InsertServiceName(int groupId)
        {
            Write.ToCenter("Service Name: ");
            string? serviceName = Console.ReadLine();

            switch (ServiceService.CheckName(serviceName))
            {
                case 0:
                    Console.WriteLine();
                    Write.LineToCenter("Service Name is required");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }

            Service? service = ServiceService.GetServiceByName(serviceName, groupId);
            if (service == null)
            {
                Console.WriteLine();
                Write.LineToCenter("Service doesn't exist");
                Console.ReadKey();
                Print(groupId);
            }
            return serviceName;
        }
    }
}
