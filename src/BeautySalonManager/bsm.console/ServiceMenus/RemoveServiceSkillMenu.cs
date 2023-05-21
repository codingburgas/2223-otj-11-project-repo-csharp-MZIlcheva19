using bsm.bll;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class RemoveServiceSkillMenu
    {
        public static void Print(Service service)
        {
            Console.Clear();
            Console.WriteLine("Remove Service Skill");
            Console.WriteLine();

            List<Skill> skillList = SkillService.GetServicesSkills(service.Id);

            foreach (Skill skill in skillList)
            {
                Console.WriteLine(skill.Name);
            }
            Console.WriteLine();

            Console.Write("Skill Name: ");
            string skillName = Console.ReadLine();

            ServiceSkillService.RemoveServiceSkill(service.GroupId, service.Name, skillName);

            Console.WriteLine();
            Console.WriteLine("Service Skill Removed");
            Console.ReadKey();
            ServiceEditListMenu.Print();
        }
    }
}
