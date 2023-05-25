using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;

namespace wm.tests.Repositories
{
    public class ServiceRepositoryTests
	{
        private BeautySalonContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.Services.Add(new Service
			{
                Name = "Service1",
                Price = 0m,
                Time = new TimeSpan(0),
                GroupId = 1
            });
            _context.Services.Add(new Service
			{
				Name = "Service2",
				Price = 0m,
				Time = new TimeSpan(0),
				GroupId = 2
			});
            _context.Services.Add(new Service
			{
				Name = "Service3",
				Price = 0m,
				Time = new TimeSpan(0),
				GroupId = 3
			});

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<Service> expected = new(){
                new Service
				{
					Id = 1,
					Name = "Service1",
				    Price = 0m,
				    Time = new TimeSpan(0),
				    GroupId = 1
				},
                new Service
				{
					Id = 2,
					Name = "Service2",
				    Price = 0m,
				    Time = new TimeSpan(0),
				    GroupId = 2
				},
                new Service
				{
                    Id = 3,
					Name = "Service3",
				    Price = 0m,
				    Time = new TimeSpan(0),
				    GroupId = 3
				}
            };

            ServiceRepository serviceRepository = new(_context);
            List<Service> actual = serviceRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

			List<Service> expected = new(){
				new Service
				{
					Id = 1,
					Name = "Service1",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 1
				},
				new Service
				{
					Id = 2,
					Name = "Service2",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 2
				},
				new Service
				{
					Id = 3,
					Name = "Service3",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 3
				},
				new Service
				{
					Id = 4,
					Name = "Service4",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 4
				}
			};

            Service row = new Service
            {
                Id = 4,
                Name = "Service4",
                Price = 0m,
                Time = new TimeSpan(0),
                GroupId = 4
            };

			ServiceRepository serviceRepository = new(_context);
			serviceRepository.AddRow(row);
            List<Service> actual = _context.Services.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_UpdateRow()
        {
            _context.ChangeTracker.Clear();

			List<Service> expected = new(){
				new Service
				{
					Id = 1,
					Name = "Service1",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 1
				},
				new Service
				{
					Id = 2,
					Name = "Service4",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 4
				},
				new Service
				{
					Id = 3,
					Name = "Service3",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 3
				},
			};

			Service updateRow = new Service
            {
				Id = 2,
				Name = "Service4",
				Price = 0m,
				Time = new TimeSpan(0),
				GroupId = 4
			};

            ServiceRepository serviceRepository = new(_context);
			serviceRepository.UpdateRow(updateRow);
            List<Service> actual = _context.Services.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

			List<Service> expected = new(){
				new Service
				{
					Id = 1,
					Name = "Service1",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 1
				},
				new Service
				{
					Id = 3,
					Name = "Service3",
					Price = 0m,
					Time = new TimeSpan(0),
					GroupId = 3
				},
			};

			Service row = new Service
            {
				Id = 2,
				Name = "Service3",
				Price = 0m,
				Time = new TimeSpan(0),
				GroupId = 2
			};

            ServiceRepository serviceRepository = new(_context);
			serviceRepository.DeleteRow(row);
            List<Service> actual = _context.Services.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}