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

            string name = InsertServiceName(groupId);
            decimal price = InsertServicePrice(groupId);
            Console.WriteLine("\nInput only minutes");
            TimeSpan time = InsertServiceTime(groupId);

            ServiceService.AddRow(name, price, time, groupId);

            Console.WriteLine();
            Console.WriteLine("Skill Added");
            ServiceEditListMenu.Print();
        }

        private static string InsertServiceName(int groupId)
        {
            Console.Write("Group Name: ");
            string? groupName = Console.ReadLine();

            switch (ServiceService.CheckName(groupName))
            {
                case 0:
                    Console.WriteLine("\nService Name is required");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                case 1:
                    Console.WriteLine("\nService Name must not have numbers");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }
            return groupName;
        }

        private static decimal InsertServicePrice(int groupId)
        {
            Console.Write("Service Price: ");
            string price = Console.ReadLine();

            switch (ServiceService.CheckPrice(price))
            {
                case 0:
                    Console.WriteLine("\nService Price is required");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                case 1:
                    Console.WriteLine("\nService Price must not have letters");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }
            return decimal.Parse(price);
        }

        private static TimeSpan InsertServiceTime(int groupId)
        {
            Console.Write("Service Time: ");
            string time = Console.ReadLine();

            switch (ServiceService.CheckTime(time))
            {
                case 0:
                    Console.WriteLine("\nService Time is required");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                case 1:
                    Console.WriteLine("\nService Time must not have letters");
                    Console.ReadKey();
                    Print(groupId);
                    break;
                default: break;
            }
            return TimeSpan.FromMinutes(int.Parse(time));
        }
    }
}
