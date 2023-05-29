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
    internal class DeleteSkillMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Delete Skill");
            Console.WriteLine();

            string name = InsertSkillName();

            SkillService.DeleteSkill(name);

            Console.WriteLine();
            Write.LineToCenter("Skill Deleted");
            SkillsEditMenu.Print();
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
