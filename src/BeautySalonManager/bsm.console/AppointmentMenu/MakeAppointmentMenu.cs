using bsm.bll;
using bsm.dal.Models; 
using bsm.util;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class MakeAppointmentMenu
    {
        // Method to print the Make Appointment menu for a specific service group
        public static void Print(int groupId)
        {
            Console.Clear();
            Console.WriteLine("Create Appointment");
            Console.WriteLine("Write [B] to go Back");
            Console.WriteLine();

            int loggedUserId = UserLog.LoggedUser.Id;

            // Prompting the user to insert the service name
            string service = InsertServiceName(groupId);

            // Prompting the user to insert the appointment date
            DateTime date = InsertAppointmentDate(loggedUserId, groupId);

            // Creating the appointment
            if (AppointmentService.CreateAppointment(date, groupId, service, loggedUserId))
            {
                Console.WriteLine("\nAppointment Created");
            }
            else
            {
                Console.WriteLine("\nAppointment Not Created");
            }

            Console.ReadKey();
            ServiceListMenu.Print();
        }

        // Method to insert the service name for the appointment
        private static string InsertServiceName(int groupId)
        {
            Console.Write("Service Name: ");
            var serviceName = Console.ReadLine();

            if (serviceName.ToUpper() == "B")
            {
                ServiceListMenu.Print();
            }
            if (serviceName.IsNullOrEmpty())
            {
                Console.WriteLine("\nName is required");
                Console.ReadKey();
                Print(groupId);
            }

            // Retrieving the service by name and group ID
            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            if (service == null)
            {
                Console.WriteLine("\nService doesn't exist");
                Console.ReadKey();
                Print(groupId);
            }

            return serviceName;
        }

        // Method to insert the appointment date and time
        private static DateTime InsertAppointmentDate(int userId, int groupId)
        {
            Console.WriteLine("dd.MM.yyyy:HH.mm");
            Console.Write("Date and time: ");
            var appointmentDate = Console.ReadLine();

            if (appointmentDate.ToUpper() == "B")
            {
                ServiceListMenu.Print();
            }
            if (appointmentDate.IsNullOrEmpty())
            {
                Console.WriteLine("\nDate is required");
                Console.ReadKey();
                Print(groupId);
            }

            DateTime parsedDate;
            if (!DateTime.TryParseExact(appointmentDate, "dd.MM.yyyy:HH.mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                Console.WriteLine("\nDate is invalid");
                Console.ReadKey();
                Print(groupId);
            }
            if (parsedDate < DateTime.Now)
            {
                Console.WriteLine("\nDate has already passed");
                Console.ReadKey();
                Print(groupId);
            }

            return parsedDate;
        }
    }
}
