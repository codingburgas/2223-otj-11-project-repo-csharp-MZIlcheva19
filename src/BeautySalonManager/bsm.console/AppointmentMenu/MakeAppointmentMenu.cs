using bsm.bll;
using bsm.util;
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
            Console.WriteLine("Create Appointment");

            string service = Console.ReadLine();
            Console.WriteLine("dd.MM.yyyy");
            DateTime date;
            DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            if(AppointmentService.CreateAppointment(date, groupId, service, UserLog.LoggedUser.Id))
            {
                Console.WriteLine("\nCreated");
            }
            else
            {
                Console.WriteLine("\nNot created");
            }

            Console.ReadKey();
            ServiceListMenu.Print();
        }
    }
}
