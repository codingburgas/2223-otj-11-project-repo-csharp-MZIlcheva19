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
        // Method to print the appointments list
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Appointments List");
            Console.WriteLine();

            // Retrieving all appointments
            List<Appointment> appointments = AppointmentService.GetAll();

            // Checking if there are no appointments
            if (appointments.IsNullOrEmpty())
            {
                Console.WriteLine("No Appointments");
            }
            else
            {
                Console.WriteLine("Date : Time : Group : Service : Customer : Employee");
                Console.WriteLine();
                // Looping through each appointment
                foreach (Appointment appointment in appointments)
                {
                    // Retrieving the associated service and its group
                    Service service = ServiceService.GetServiceById(appointment.ServiceId);
                    string serviceGroupName = ServiceGroupService.GetGroupNameById(service.GroupId);

                    // Retrieving the associated customer and employee
                    User customer = UserService.GetUserById(appointment.CustomerId);
                    User employee = UserService.GetUserById(appointment.EmployeeId);

                    // Displaying appointment details
                    Console.WriteLine($"{appointment.Date.ToString("dd.MM.yyyy")}y. : {appointment.Date.Hour}.{appointment.Date.Minute} : {serviceGroupName} : {service.Name} : {customer.Username} : {employee.Username}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
            MainMenu.Print();
        }
    }
}
