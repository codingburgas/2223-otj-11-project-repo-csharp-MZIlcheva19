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
        public static void Print(int groupId)
        {
            Console.Clear();
            Write.LineToCenter("Create Appointment");
            Write.LineToCenter("Write [B] to go Back");
            Console.WriteLine();

            int loggedUserId = UserLog.LoggedUser.Id;

            string service = InsertServiceName(groupId);
            DateTime date = InsertAppointmentDate(loggedUserId, groupId);
            
            if(AppointmentService.CreateAppointment(date, groupId, service, loggedUserId))
            {
                Console.WriteLine();
                Write.LineToCenter("Appointment Created");
            }
            else
            {
                Console.WriteLine();
                Write.LineToCenter("Appointment Not Created");
            }

            Console.ReadKey();
            MainMenu.Print();
        }

        private static string InsertServiceName(int groupId)
        {
            Write.ToCenter("Service Name: ");
            var serviceName = Console.ReadLine();

            if (serviceName.ToUpper() == "B")
            {
                ServiceListMenu.Print();
            }
            if (serviceName.IsNullOrEmpty())
            {
                Console.WriteLine();
                Write.LineToCenter("Name is required");
                Console.ReadKey();
                Print(groupId);
            }

            Service service = ServiceService.GetServiceByName(serviceName, groupId);
            if (service == null)
            {
                Console.WriteLine();
                Write.LineToCenter("Service doesn't exist");
                Console.ReadKey();
                Print(groupId);
            }

            return serviceName;
        }

        private static DateTime InsertAppointmentDate(int userId, int groupId)
        {
            Write.LineToCenter("dd.MM.yyyy:HH.mm");
            Write.ToCenter("Date and time: ");
            var appointmentDate = Console.ReadLine();

            if (appointmentDate.ToUpper() == "B")
            {
                ServiceListMenu.Print();
            }
            if (appointmentDate.IsNullOrEmpty())
            {
                Console.WriteLine();
                Write.LineToCenter("Date is required");
                Console.ReadKey();
                Print(groupId);
            }

            DateTime parsedDate;
            if (!DateTime.TryParseExact(appointmentDate, "dd.MM.yyyy:HH.mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                Console.WriteLine();
                Write.LineToCenter("Date is invalid");
                Console.ReadKey();
                Print(groupId);
            }
            if (parsedDate < DateTime.Now)
            {
                Console.WriteLine();
                Write.LineToCenter("Date has already passed");
                Console.ReadKey();
                Print(groupId);
            }

            return parsedDate;
        }
    }
}
