using bsm.bll;
using bsm.dal.Models;
using bsm.util;
using Microsoft.IdentityModel.Tokens;
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
            Write.LineToCenter("Remove Service Skill");
            Console.WriteLine();

            List<Skill> skillList = SkillService.GetServicesSkills(service.Id);

            if (!skillList.IsNullOrEmpty())
            {
                Write.LineToCenter("Service Name");
                foreach (Skill skill in skillList)
                {
                    Write.LineToCenter(skill.Name);
                }
                Console.WriteLine();
            }
            else
            {
                Write.LineToCenter("No Services");
                Console.WriteLine();
            }

            string skillName = InsertServiceSkill(service);

            ServiceSkillService.RemoveServiceSkill(service.GroupId, service.Name, skillName);

            Console.WriteLine();
            Write.LineToCenter("Service Skill Removed");
            Console.ReadKey();
            ServiceEditListMenu.Print();
        }

        private static string InsertServiceSkill(Service service)
        {
            Write.ToCenter("Skill Name: ");
            string skillName = Console.ReadLine();


            if (skillName.IsNullOrEmpty())
            {
                Console.WriteLine();
                Write.LineToCenter("Skill Name is required");
                Console.ReadKey();
                Print(service);
            }

            Skill skill = SkillService.GetSkillByName(skillName);
            if (skill == null)
            {
                Console.WriteLine();
                Write.LineToCenter("Skill doesn't exist");
                Console.ReadKey();
                Print(service);
            }

            return skillName;
        }
    }
}
