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
    internal class AddEmployeeSkillMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Add Skill");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetAll();

            if(!skills.IsNullOrEmpty())
            {
                List<Skill> userSkill = SkillService.GetUsersSkills(UserLog.LoggedUser.Id);
                List<Skill> resultSkills = skills.Where(s => !userSkill.Any(us => us.Id == s.Id)).ToList();

                foreach (Skill skill in resultSkills)
                {
                    Write.LineToCenter(skill.Name);
                }
                Console.WriteLine();
            }
            else
            {
                Write.LineToCenter("No skills added");
                Console.WriteLine();
            }

            string name = InsertEmployeeSkill();

            UserSkillService.AddSkillToUser(UserLog.LoggedUser, name);

            Console.WriteLine();
            Write.LineToCenter("Skill Added");
            Console.ReadKey();
            EmployeeSkillsMenu.Print();
        }

        private static string InsertEmployeeSkill()
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
