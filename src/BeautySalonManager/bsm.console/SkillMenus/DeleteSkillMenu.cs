using bsm.bll;
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
            Console.WriteLine("Delete Skill");
            Console.WriteLine();

            Console.WriteLine("Skill Name: ");
            string name = Console.ReadLine();

            SkillService.DeleteSkill(name);

            Console.WriteLine();
            Console.WriteLine("Skill Deleted");
            SkillsEditMenu.Print();
        }
    }
}
