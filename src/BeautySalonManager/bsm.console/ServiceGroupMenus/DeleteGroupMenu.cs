using bsm.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class DeleteGroupMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Delete Group");
            Console.WriteLine();

            Console.Write("Group Name: ");
            string name = Console.ReadLine();

            ServiceGroupService.DeleteGroup(name);

            Console.WriteLine();
            Console.WriteLine("Group Deleted");
            Console.ReadKey();
            ServiceGroupEditMenu.Print();
        }
    }
}
