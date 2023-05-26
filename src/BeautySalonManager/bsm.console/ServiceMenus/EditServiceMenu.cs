using bsm.bll;
using bsm.dal.Models;

namespace bsm.console
{
    internal class EditServiceMenu
    {
        public static void Print(int groupId)
        {
            Console.Clear();
            Console.WriteLine("Edit Service");
            Console.WriteLine(ServiceGroupService.GetGroupNameById(groupId));
            Console.WriteLine();

            string serviceName = InsertOldServiceName(groupId);
            string newName = InsertNewServiceName(groupId);
            decimal newPrice = InsertNewServicePrice(groupId);
            Console.WriteLine("\nInput only minutes");
            TimeSpan newTime = InsertNewServiceTime(groupId);

            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            ServiceService.EditRow(service, newName, newPrice, newTime);

            Console.WriteLine();
            Console.WriteLine("Service Edited");
            ServiceEditListMenu.Print();
        }

        private static string InsertOldServiceName(int groupId)
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

        private static string InsertNewServiceName(int groupId)
        {
            Console.Write("Service New Name: ");
            string? serviceName = Console.ReadLine();

            switch (ServiceService.CheckName(serviceName))
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

            Service? service = ServiceService.GetServiceByName(serviceName, groupId);
            if (service != null)
            {
                Console.WriteLine("\nService Name already taken");
                Console.ReadKey();
                Print(groupId);
            }
            return serviceName;
        }

        private static decimal InsertNewServicePrice(int groupId)
        {
            Console.Write("Service New Price: ");
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

        private static TimeSpan InsertNewServiceTime(int groupId)
        {
            Console.Write("Service New Time: ");
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
