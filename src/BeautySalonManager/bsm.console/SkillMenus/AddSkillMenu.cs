﻿using bsm.bll;
using bsm.dal.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class AddSkillMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Add Skill");
            Console.WriteLine();

            string name = InsertSkillName();

            SkillService.AddRow(name);

            Console.WriteLine();
            Console.WriteLine("Skill Added");
            SkillsEditMenu.Print();
        }

        private static string InsertSkillName()
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
