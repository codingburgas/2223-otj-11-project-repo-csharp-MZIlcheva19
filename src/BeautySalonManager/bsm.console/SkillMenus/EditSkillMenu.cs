using bsm.bll;
using bsm.dal.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class EditSkillMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Edit Skill");
            Console.WriteLine();

            string oldName = InsertOldSkillName();
            string newName = InsertNewSkillName();

            SkillService.EditRow(oldName, newName);

            Console.WriteLine();
            Console.WriteLine("Skill Edited");
            SkillsEditMenu.Print();
        }

        private static string InsertOldSkillName()
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

        private static string InsertNewSkillName()
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
            if (skill != null)
            {
                Console.WriteLine("\nSkill already exist");
                Console.ReadKey();
                Print();
            }

            return skillName;
        }
    }
}
