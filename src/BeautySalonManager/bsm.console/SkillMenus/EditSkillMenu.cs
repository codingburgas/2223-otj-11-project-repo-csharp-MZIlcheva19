﻿using bsm.bll;
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
    internal class EditSkillMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Edit Skill");
            Console.WriteLine();

            string oldName = InsertOldSkillName();
            string newName = InsertNewSkillName();

            SkillService.EditRow(oldName, newName);

            Console.WriteLine();
            Write.LineToCenter("Skill Edited");
            SkillsEditMenu.Print();
        }

        private static string InsertOldSkillName()
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

        private static string InsertNewSkillName()
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
            if (skill != null)
            {
                Console.WriteLine();
                Write.LineToCenter("Skill already exist");
                Console.ReadKey();
                Print();
            }

            return skillName;
        }
    }
}
