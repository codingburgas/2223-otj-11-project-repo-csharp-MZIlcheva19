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

        private static string InsertServiceName(int groupId)
        {
            Console.Write("Service Name: ");
            string? serviceName = Console.ReadLine();

            switch (ServiceService.CheckName(serviceName))
            {
                case 0:
                    Console.WriteLine("\nService Name is required");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }

            Service? service = ServiceService.GetServiceByName(serviceName, groupId);
            if (service == null)
            {
                Console.WriteLine("\nService doesn't exist");
                Console.ReadKey();
                Print(groupId);
            }
            return serviceName;
        }
    }
}
