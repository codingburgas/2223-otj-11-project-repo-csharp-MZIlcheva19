using bsm.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class AddServiceMenu
    {
        public static void Print(int groupId)
        {
            Console.Clear();
            Console.WriteLine("Add Service");
            Console.WriteLine(ServiceGroupService.GetGroupNameById(groupId));
            Console.WriteLine();

            string name = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nInput only minutes");
            TimeSpan time = TimeSpan.FromMinutes(int.Parse(Console.ReadLine()));

            ServiceService.AddRow(name, price, time, groupId);

            Console.WriteLine();
            Console.WriteLine("Service Added");
            ServiceEditListMenu.Print();
        }
    }
}
