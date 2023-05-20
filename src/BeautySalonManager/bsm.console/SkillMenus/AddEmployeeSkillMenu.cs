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
    internal class AddEmployeeSkillMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Add Skill");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetAll();

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.Name);
            }
            Console.WriteLine();

            string name = Console.ReadLine();

            UserSkillService.AddSkillToUser(UserLog.LoggedUser, name);

            Console.WriteLine();
            Console.WriteLine("Skill Added");
            Console.ReadKey();
            EmployeeSkillsMenu.Print();
        }
    }
}
