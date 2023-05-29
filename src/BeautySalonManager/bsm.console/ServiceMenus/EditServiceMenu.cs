using bsm.bll;
using bsm.dal.Models;
using bsm.util;

namespace bsm.console
{
    internal class EditServiceMenu
    {
        public static void Print(int groupId)
        {
            Console.Clear();
            Write.LineToCenter("Edit Service");
            Write.LineToCenter($"Group: {ServiceGroupService.GetGroupNameById(groupId)}");
            Console.WriteLine();

            string serviceName = InsertOldServiceName(groupId);
            string newName = InsertNewServiceName(groupId);
            decimal newPrice = InsertNewServicePrice(groupId);

            Console.WriteLine();
            Write.LineToCenter("Input only minutes");
            TimeSpan newTime = InsertNewServiceTime(groupId);

            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            ServiceService.EditRow(service, newName, newPrice, newTime);

            Console.WriteLine();
            Write.LineToCenter("Service Edited");
            ServiceEditListMenu.Print();
        }

        private static string InsertOldServiceName(int groupId)
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

        private static string InsertNewServiceName(int groupId)
        {
            Write.ToCenter("Service New Name: ");
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
            if (service != null)
            {
                Write.LineToCenter("Service Name already taken");
                Console.ReadKey();
                Print(groupId);
            }
            return serviceName;
        }

        private static decimal InsertNewServicePrice(int groupId)
        {
            Write.ToCenter("Service New Price: ");
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

        private static TimeSpan InsertNewServiceTime(int groupId)
        {
            Write.ToCenter("Service New Time: ");
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
