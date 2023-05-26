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
            Console.WriteLine("Add Skill");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetAll();

            if(!skills.IsNullOrEmpty())
            {
                List<Skill> userSkill = SkillService.GetUsersSkills(UserLog.LoggedUser.Id);
                List<Skill> resultSkills = skills.Where(s => !userSkill.Any(us => us.Id == s.Id)).ToList();

                foreach (Skill skill in resultSkills)
                {
                    Console.WriteLine(skill.Name);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No skills added");
                Console.WriteLine();
            }

            string name = InsertEmployeeSkill();

            UserSkillService.AddSkillToUser(UserLog.LoggedUser, name);

            Console.WriteLine();
            Console.WriteLine("Skill Added");
            Console.ReadKey();
            EmployeeSkillsMenu.Print();
        }

        private static string InsertEmployeeSkill()
        {
            Console.Write("Skill Name: ");
            string skillName = Console.ReadLine();


            if (skillName.IsNullOrEmpty())
            {
                Console.WriteLine("\nSkill Name is required");
                Console.ReadKey();
                Print();
            }

            Skill skill = SkillService.GetSkillByName(skillName);
            if (skill == null)
            {
                Console.WriteLine("\nSkill doesn't exist");
                Console.ReadKey();
                Print();
            }

            return skillName;
        }
    }
}
