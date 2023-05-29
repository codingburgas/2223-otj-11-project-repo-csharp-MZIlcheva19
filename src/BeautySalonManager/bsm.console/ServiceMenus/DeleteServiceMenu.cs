using bsm.bll;
using bsm.dal.Models;
using bsm.util;
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
            Write.LineToCenter("Delete Service");
            Write.LineToCenter($"Group: {ServiceGroupService.GetGroupNameById(groupId)}");
            Console.WriteLine();

            string serviceName = InsertServiceName(groupId);

            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            ServiceService.DeleteRow(service);

            Console.WriteLine();
            Write.LineToCenter("Service Deleted");
            ServiceEditListMenu.Print();
        }

        private static string InsertServiceName(int groupId)
        {
            Write.ToCenter("Service Name: ");
            string? serviceName = Console.ReadLine();

            switch (ServiceService.CheckName(serviceName))
            {
                case 0:
                    Console.WriteLine();
                    Write.LineToCenter("Service Name is required");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }

            Service? service = ServiceService.GetServiceByName(serviceName, groupId);
            if (service == null)
            {
                Console.WriteLine();
                Write.LineToCenter("Service doesn't exist");
                Console.ReadKey();
                Print(groupId);
            }
            return serviceName;
        }
    }
}
