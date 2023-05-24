using bsm.bll;
using bsm.dal.Models;
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

            Console.WriteLine("Old Skill Name: ");
            string oldName = Console.ReadLine();
            Console.WriteLine("New Skill Name: ");
            string newName = Console.ReadLine();

            SkillService.EditRow(oldName, newName);

            Console.WriteLine();
            Console.WriteLine("Skill Edited");
            SkillsEditMenu.Print();
        }
    }
}
