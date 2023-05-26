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
    internal class AddServiceSkillMenu
    {
        public static void Print(Service service)
        {
            Console.Clear();
            Console.WriteLine("Add Skill to Service");
            Console.WriteLine(); 
            
            List<Skill> skills = SkillService.GetAll();

            if (!skills.IsNullOrEmpty())
            {
                Console.WriteLine("Skill Name");
                foreach (Skill skill in skills)
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

            string skillName = InsertServiceSkill(service);

            ServiceSkillService.AddServiceSkill(service.GroupId, service.Name, skillName);

            Console.WriteLine();
            Console.WriteLine("Service Skill Added");
            Console.ReadKey();
            ServiceEditListMenu.Print();
        }

        private static string InsertServiceSkill(Service service)
        {
            Console.Write("Skill Name: ");
            string skillName = Console.ReadLine();


            if(skillName.IsNullOrEmpty())
            {
                Console.WriteLine("\nSkill Name is required");
                Console.ReadKey();
                Print(service);
            }

            Skill skill = SkillService.GetSkillByName(skillName);
            if(skill == null)
            {
                Console.WriteLine("\nSkill doesn't exist");
                Console.ReadKey();
                Print(service);
            }

            return skillName;
        }
    }
}
