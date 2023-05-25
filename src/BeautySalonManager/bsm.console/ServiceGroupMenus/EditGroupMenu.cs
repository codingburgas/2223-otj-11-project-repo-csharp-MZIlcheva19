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

            Console.Write("Group Old Name: ");
            string oldName = Console.ReadLine();
            Console.Write("Group New Name: ");
            string newName = Console.ReadLine();

            ServiceGroupService.EditGroup(oldName, newName);

            Console.WriteLine();
            Console.WriteLine("Group Edited");
            ServiceGroupEditMenu.Print();
        }
    }
}
