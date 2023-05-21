using bsm.dal.Data;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.dal.Repositories
{
    public class AppointmentRepository
    {
        private readonly BeautySalonContext _context;

        public AppointmentRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAllByUserId(int userId)
        {
            IEnumerable<Appointment> list = _context.Appointments
                .Where(a => a.CustomerId == userId || a.EmployeeId == userId);

            return list;
        }

        public void AddRow(Appointment appointment) 
        {
            if (appointment != null)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(Appointment appointment)
        {
            if(appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }
    }
}
