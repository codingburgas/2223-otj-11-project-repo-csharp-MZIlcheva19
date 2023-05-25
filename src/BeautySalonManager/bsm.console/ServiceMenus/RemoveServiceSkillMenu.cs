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
    internal class RemoveServiceSkillMenu
    {
        public static void Print(Service service)
        {
            Console.Clear();
            Console.WriteLine("Remove Service Skill");
            Console.WriteLine();

            List<Skill> skillList = SkillService.GetServicesSkills(service.Id);

            if (!skillList.IsNullOrEmpty())
            {
                Console.WriteLine("Service Name");
                foreach (Skill skill in skillList)
                {
                    Console.WriteLine(skill.Name);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Services");
                Console.WriteLine();
            }

            Console.Write("Skill Name: ");
            string skillName = Console.ReadLine();

            ServiceSkillService.RemoveServiceSkill(service.GroupId, service.Name, skillName);

            Console.WriteLine();
            Console.WriteLine("Service Skill Removed");
            Console.ReadKey();
            ServiceEditListMenu.Print();
        }
    }
}
