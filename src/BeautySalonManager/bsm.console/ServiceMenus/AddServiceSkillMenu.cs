using bsm.bll;
using bsm.dal.Models;
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

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.Name);
            }
            Console.WriteLine();

            Console.Write("Skill Name: ");
            string skillName = Console.ReadLine();

            ServiceSkillService.AddServiceSkill(service.GroupId, service.Name, skillName);

            Console.WriteLine();
            Console.WriteLine("Service Skill Added");
            Console.ReadKey();
            ServiceEditListMenu.Print();
        }
    }
}
