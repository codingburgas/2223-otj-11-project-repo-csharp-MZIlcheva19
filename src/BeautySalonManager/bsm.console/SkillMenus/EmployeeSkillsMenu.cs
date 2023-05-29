using bsm.bll;
using bsm.dal.Models;
using bsm.util;
using Microsoft.IdentityModel.Tokens;
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
            Write.LineToCenter("Your Skills");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetUsersSkills(UserLog.LoggedUser.Id);

            if (skills.IsNullOrEmpty())
            {
                Write.LineToCenter("You have no skills");
            }
            else
            {
                Write.LineToCenter("Name");
                foreach (Skill skill in skills)
                {
                    Write.LineToCenter(skill.Name);
                }
            }

            Console.WriteLine();
            Write.LineToCenter("[A] Add Skill  [R] Remove Skill  [B] Back");

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
