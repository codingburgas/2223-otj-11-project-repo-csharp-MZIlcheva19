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
    internal class RemoveEmployeeSkillMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Remove Skill");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetUsersSkills(UserLog.LoggedUser.Id);

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Skill Name: ");
            string name = Console.ReadLine();

            UserSkillService.RemoveSkill(UserLog.LoggedUser, name);

            Console.WriteLine();
            Console.WriteLine("Skill Removed");
            Console.ReadKey();
            EmployeeSkillsMenu.Print();
        }
    }
}
