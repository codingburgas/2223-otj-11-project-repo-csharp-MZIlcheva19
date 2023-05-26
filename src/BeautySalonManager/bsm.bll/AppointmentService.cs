using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;
using System.Collections.Generic;

namespace bsm.bll
{
    public class AppointmentService
    {
        public static List<Appointment> GetAll()
        {
            using (var context = new BeautySalonContext())
            {
                AppointmentRepository appointmentRepository = new(context);

                return appointmentRepository.GetAll().ToList();
            }
        }

        public static bool CreateAppointment(DateTime date, int groupId, string serviceName, int customerId)
        {
            using (var context = new BeautySalonContext())
            {
                AppointmentRepository appointmentRepository = new(context);

                int serviceId = ServiceService.GetServiceByName(serviceName, groupId).Id;

                Appointment appointment = new Appointment()
                {
                    Date = date,
                    ServiceId = serviceId,
                    CustomerId = customerId
                };

                List<Skill> serviceSkills = SkillService.GetServicesSkills(serviceId);
                List<User> employees = UserService.GetEmployees();
                bool checkEmployees = false;

                foreach (User employee in employees)
                {
                    List<Skill> employeeSkills = SkillService.GetUsersSkills(employee.Id);

                    List<bool> skillsMatches = new List<bool>();
                    for (int i = 0; i < serviceSkills.Count; i++)
                    {
                        bool flag = false;
                        foreach(Skill skill in employeeSkills)
                        {
                            if(skill.Id == serviceSkills[i].Id)
                            {
                                flag = true;
                                break;
                            }
                        }
                        skillsMatches.Add(flag);
                    }

                    if (skillsMatches.Where(c => c).Count() == serviceSkills.Count)
                    {
                        checkEmployees = true;
                        appointment.EmployeeId = employee.Id;
                        break;
                    }
                }

                if (checkEmployees)
                {
                    appointmentRepository.AddRow(appointment);
                }
                return checkEmployees;
            }
        }

        public static void DeleteUserAppointments(User user)
        {
            using (var context = new BeautySalonContext())
            {
                AppointmentRepository appointmentRepository = new(context);

                List<Appointment> appointments = appointmentRepository.GetAllByUserId(user.Id).ToList();

                foreach(Appointment appointment in appointments)
                {
                    appointmentRepository.DeleteRow(appointment);
                }
            }
        }
    }
}
