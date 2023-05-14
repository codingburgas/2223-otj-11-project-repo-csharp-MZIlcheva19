using bsm.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class EditGroupMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Edit Group");
            Console.WriteLine();

            string oldName = Console.ReadLine();
            string newName = Console.ReadLine();

            ServiceGroupService.EditGroup(oldName, newName);

            Console.WriteLine();
            Console.WriteLine("Group Edited");
            ServiceEditMenu.Print();
        }
    }
}
