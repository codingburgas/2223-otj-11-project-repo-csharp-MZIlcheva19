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

            Console.WriteLine("Skill name: ");
            string name = Console.ReadLine();

            UserSkillService.AddSkillToUser(UserLog.LoggedUser, name);

            Console.WriteLine();
            Console.WriteLine("Skill Added");
            Console.ReadKey();
            EmployeeSkillsMenu.Print();
        }
    }
}
