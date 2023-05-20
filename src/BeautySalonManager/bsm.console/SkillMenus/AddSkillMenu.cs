using bsm.bll;
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

            string name = Console.ReadLine();

            SkillService.AddRow(name);

            Console.WriteLine();
            Console.WriteLine("Skill Added");
            SkillsEditMenu.Print();
        }
    }
}
