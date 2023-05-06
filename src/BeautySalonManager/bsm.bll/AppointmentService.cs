using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;
using bsm.dal;

namespace bsm.bll
{
    public class AppointmentService
    {
        public static void RemoveUserAppointments(User user)
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
