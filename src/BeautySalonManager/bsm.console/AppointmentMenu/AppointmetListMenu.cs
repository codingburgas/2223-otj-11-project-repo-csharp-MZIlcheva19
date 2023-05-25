using bsm.bll;
using bsm.dal.Models;
using Microsoft.IdentityModel.Tokens;
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

            if(appointments.IsNullOrEmpty())
            {
                Console.WriteLine("No Appointments");
            }
            else
            {
                Console.WriteLine("Date : Group : Service : Customer : Employee");
                foreach (Appointment appointment in appointments)
                {
                    Service service = ServiceService.GetServiceById(appointment.ServiceId);
                    string serviceGroupName = ServiceGroupService.GetGroupNameById(service.GroupId);
                    User customer = UserService.GetUserById(appointment.CustomerId);
                    User employee = UserService.GetUserById(appointment.EmployeeId);

                    Console.WriteLine($"{appointment.Date.ToString("dd.MM.yyyy")}y. : {appointment.Date.Hour}.{appointment.Date.Minute} : {serviceGroupName} : {service.Name} : {customer.Username} : {employee.Username}");
                }
            }

            Console.WriteLine();
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
