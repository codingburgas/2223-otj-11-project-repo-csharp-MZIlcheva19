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
    internal class RemoveEmployeeSkillMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Remove Skill");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetUsersSkills(UserLog.LoggedUser.Id);

            foreach (Skill skill in skills)
            {
                Write.LineToCenter(skill.Name);
            }
            Console.WriteLine();

            string name = InsertSkillName();

            UserSkillService.RemoveSkill(UserLog.LoggedUser, name);

            Console.WriteLine();
            Write.LineToCenter("Skill Removed");
            Console.ReadKey();
            EmployeeSkillsMenu.Print();
        }

        private static string InsertSkillName()
        {
            Write.ToCenter("Skill Name: ");
            string skillName = Console.ReadLine();


            if (skillName.IsNullOrEmpty())
            {
                Console.WriteLine();
                Write.LineToCenter("Skill Name is required");
                Console.ReadKey();
                Print();
            }

            Skill skill = SkillService.GetSkillByName(skillName);
            if (skill == null)
            {
                Console.WriteLine();
                Write.LineToCenter("Skill doesn't exist");
                Console.ReadKey();
                Print();
            }

            return skillName;
        }
    }
}
