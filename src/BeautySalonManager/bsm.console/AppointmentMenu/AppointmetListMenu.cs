using bsm.bll;
using bsm.dal.Models;
using bsm.util;
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
            Write.LineToCenter("Appointments List");
            Console.WriteLine();

            AppointmentService.UpdateAppointments();
            List<Appointment> appointments = AppointmentService.GetAll();

            if(appointments.IsNullOrEmpty())
            {
                Write.LineToCenter("No Appointments");
            }
            else
            {
                Write.LineToCenter("Date : Time : Group : Service : Customer : Employee\n");
                foreach (Appointment appointment in appointments)
                {
                    Service service = ServiceService.GetServiceById(appointment.ServiceId);
                    string serviceGroupName = ServiceGroupService.GetGroupNameById(service.GroupId);
                    User customer = UserService.GetUserById(appointment.CustomerId);
                    User employee = UserService.GetUserById(appointment.EmployeeId);

                    Write.LineToCenter($"{appointment.Date.ToString("dd.MM.yyyy")}y. : {appointment.Date.Hour}.{appointment.Date.Minute} : {serviceGroupName} : {service.Name} : {customer.Username} : {employee.Username}");
                }
            }

            Console.WriteLine();
            Write.LineToCenter("Press any key to go back");
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
