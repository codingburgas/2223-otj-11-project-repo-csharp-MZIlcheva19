using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;

namespace wm.tests.Repositories
{
    public class AppointmentRepositoryTests
    {
        private BeautySalonContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.Appointments.Add(new Appointment
            {
                Id = 1,
                Date = new DateTime(2008, 5, 1, 8, 30, 52),
                ServiceId = 1,
                CustomerId = 2,
                EmployeeId = 3
            });
            _context.Appointments.Add(new Appointment
            {
                Id = 2,
                Date = new DateTime(2008, 5, 1, 8, 30, 52),
                ServiceId = 2,
                CustomerId = 1,
                EmployeeId = 2
            });
            _context.Appointments.Add(new Appointment
            {
                Id = 3,
                Date = new DateTime(2008, 5, 1, 8, 30, 52),
                ServiceId = 3,
                CustomerId = 3,
                EmployeeId = 1
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<Appointment> expected = new(){
                new Appointment
                {
                    Id = 1,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 1,
                    CustomerId = 2,
                    EmployeeId = 3
                },
                new Appointment
                {
                    Id = 2,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 2,
                    CustomerId = 1,
                    EmployeeId = 2
                },
                new Appointment
                {
                    Id = 3,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 3,
                    CustomerId = 3,
                    EmployeeId = 1
                }
            };

            AppointmentRepository appointmentRepository = new(_context);
            List<Appointment> actual = appointmentRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetAllByUserId()
        {
            _context.ChangeTracker.Clear();

            List<Appointment> expected = new(){
                new Appointment
                {
                    Id = 1,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 1,
                    CustomerId = 2,
                    EmployeeId = 3
                },
                new Appointment
                {
                    Id = 3,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 3,
                    CustomerId = 3,
                    EmployeeId = 1
                }
            };

            int userId = 3;
            AppointmentRepository appointmentRepository = new(_context);
            List<Appointment> actual = appointmentRepository.GetAllByUserId(userId).ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<Appointment> expected = new(){
                new Appointment
                {
                    Id = 1,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 1,
                    CustomerId = 2,
                    EmployeeId = 3
                },
                new Appointment
                {
                    Id = 2,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 2,
                    CustomerId = 1,
                    EmployeeId = 2
                },
                new Appointment
                {
                    Id = 3,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 3,
                    CustomerId = 3,
                    EmployeeId = 1
                },
                new Appointment
                {
                    Id = 4,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 4,
                    CustomerId = 1,
                    EmployeeId = 3
                }
            };

            Appointment row = new Appointment
            {
                Id = 4,
                Date = new DateTime(2008, 5, 1, 8, 30, 52),
                ServiceId = 4,
                CustomerId = 1,
                EmployeeId = 3
            };

            AppointmentRepository appointmentRepository = new(_context);
            appointmentRepository.AddRow(row);
            List<Appointment> actual = _context.Appointments.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<Appointment> expected = new(){
                new Appointment
                {
                    Id = 1,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 1,
                    CustomerId = 2,
                    EmployeeId = 3
                },
                new Appointment
                {
                    Id = 3,
                    Date = new DateTime(2008, 5, 1, 8, 30, 52),
                    ServiceId = 3,
                    CustomerId = 3,
                    EmployeeId = 1
                }
            };

            Appointment row = new Appointment
            {
                Id = 2,
                Date = new DateTime(2008, 5, 1, 8, 30, 52),
                ServiceId = 2,
                CustomerId = 1,
                EmployeeId = 2
            };

            AppointmentRepository appointmentRepository = new(_context);
			appointmentRepository.DeleteRow(row);
            List<Appointment> actual = _context.Appointments.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}