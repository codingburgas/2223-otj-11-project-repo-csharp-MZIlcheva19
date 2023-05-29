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
    internal class AddServiceMenu
    {
        public static void Print(int groupId)
        {
            Console.Clear();
            Write.LineToCenter("Add Service");
            Console.WriteLine();
            Write.LineToCenter($"Group: {ServiceGroupService.GetGroupNameById(groupId)}");
            Console.WriteLine();

            string name = InsertServiceName(groupId);
            decimal price = InsertServicePrice(groupId);
            Console.WriteLine();
            Write.LineToCenter("Input only minutes");
            TimeSpan time = InsertServiceTime(groupId);

            ServiceService.AddRow(name, price, time, groupId);

            Console.WriteLine();
            Write.LineToCenter("Skill Added");
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
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Service Name must not have numbers");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }

            Service? service = ServiceService.GetServiceByName(serviceName, groupId);
            if(service != null)
            {
                Console.WriteLine();
                Write.LineToCenter("Service Name is taken");
                Console.ReadKey();
                Print(groupId);
            }

            return serviceName;
        }

        private static decimal InsertServicePrice(int groupId)
        {
            Write.ToCenter("Service Price: ");
            string price = Console.ReadLine();

            switch (ServiceService.CheckPrice(price))
            {
                case 0:
                    Console.WriteLine();
                    Write.LineToCenter("Service Price is required");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Service Price must not have letters");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }
            return decimal.Parse(price);
        }

        private static TimeSpan InsertServiceTime(int groupId)
        {
            Write.ToCenter("Service Time: ");
            string time = Console.ReadLine();

            switch (ServiceService.CheckTime(time))
            {
                case 0:
                    Console.WriteLine();
                    Write.LineToCenter("Service Time is required");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Service Time must not have letters");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }
            return TimeSpan.FromMinutes(int.Parse(time));
        }
    }
}
