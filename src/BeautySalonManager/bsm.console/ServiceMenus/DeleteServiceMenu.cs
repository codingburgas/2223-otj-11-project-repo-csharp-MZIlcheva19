using bsm.bll;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class DeleteServiceMenu
    {
        public static void Print(int groupId)
        {
            Console.Clear();
            Console.WriteLine("Delete Service");
            Console.WriteLine(ServiceGroupService.GetGroupNameById(groupId));
            Console.WriteLine();

            Console.Write("Service Name: ");
            string serviceName = Console.ReadLine();

            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            ServiceService.DeleteRow(service);

            Console.WriteLine();
            Console.WriteLine("Service Deleted");
            ServiceEditListMenu.Print();
        }
    }
}
