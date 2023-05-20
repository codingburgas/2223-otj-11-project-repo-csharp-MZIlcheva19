using bsm.bll;
using bsm.console.UserMenus;
using bsm.dal.Models;
using bsm.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class EmployeeSkillsMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Your Skills");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetUsersSkills(UserLog.LoggedUser.Id);

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.Name);
            }

            Console.WriteLine();
            Console.WriteLine("[A] Add Skill  [R] Remove Skill  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': AddEmployeeSkillMenu.Print(); break;
                    case 'R': RemoveEmployeeSkillMenu.Print(); break;
                    case 'B': MainMenu.Print(); break;
                    default: MainMenu.Print(); break;
                }
            }
        }
    }
}
