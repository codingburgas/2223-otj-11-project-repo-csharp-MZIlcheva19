using bsm.bll;
using bsm.dal.Models;
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
            Console.WriteLine("See Skills");
            Console.WriteLine();

            Console.Write("Service Name: ");
            string serviceName = Console.ReadLine();
            Console.WriteLine();

            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            List<Skill> skills = SkillService.GetServicesSkills(service.Id);

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.Name);
            }

            Console.WriteLine();
            Console.WriteLine("[A] Add Skills  [R] Remove Skill  [B] Back");

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
    }
}
