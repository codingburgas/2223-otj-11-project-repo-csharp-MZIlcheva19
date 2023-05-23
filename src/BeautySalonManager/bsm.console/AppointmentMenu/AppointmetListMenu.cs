using bsm.bll;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class AppointmetListMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Appointments List");
            Console.WriteLine();

            List<Appointment> appointments = AppointmentService.GetAll();

            foreach (Appointment appointment in appointments)
            {
                Service service = ServiceService.GetServiceById(appointment.ServiceId);
                User customer = UserService.GetUserById(appointment.CustomerId);
                User employee = UserService.GetUserById(appointment.EmployeeId);

                Console.WriteLine($"{appointment.Date.ToString("dd.MM.yyyy")}y. : {appointment.Date.Hour}.{appointment.Date.Minute} : {service.Name} : {customer.Username} : {employee.Username}");
            }

            Console.WriteLine();
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
