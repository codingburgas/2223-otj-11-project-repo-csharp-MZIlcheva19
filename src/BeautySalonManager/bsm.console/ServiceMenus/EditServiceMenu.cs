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

            string serviceName = Console.ReadLine();
            string newName = Console.ReadLine();
            decimal newPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nInput only minutes");
            TimeSpan newTime = TimeSpan.FromMinutes(int.Parse(Console.ReadLine()));

            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            ServiceService.EditRow(service, newName, newPrice, newTime);

            Console.WriteLine();
            Console.WriteLine("Service Edited");
            ServiceEditListMenu.Print();
        }
    }
}
