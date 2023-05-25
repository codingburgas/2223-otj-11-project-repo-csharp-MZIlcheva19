using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;

namespace wm.tests.Repositories
{
    public class ServiceGroupRepositoryTests
	{
        private BeautySalonContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.ServiceGroups.Add(new ServiceGroup
            {
                Name = "ServiceGroup1"
            });
            _context.ServiceGroups.Add(new ServiceGroup
            {
				Name = "ServiceGroup2"
            });
            _context.ServiceGroups.Add(new ServiceGroup
            {
                Name = "ServiceGroup3"
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<ServiceGroup> expected = new(){
                new ServiceGroup
                {
                    Id = 1,
                    Name = "ServiceGroup1"
                },
                new ServiceGroup
                {
                    Id = 2,
                    Name = "ServiceGroup2"
                },
                new ServiceGroup
                {
                    Id = 3,
                    Name = "ServiceGroup3"
                }
            };

            ServiceGroupRepository serviceGroupRepository = new(_context);
            List<ServiceGroup> actual = serviceGroupRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetGroupByName()
        {
            _context.ChangeTracker.Clear();

            ServiceGroup expected = new ServiceGroup
            {
                Id = 2,
                Name = "ServiceGroup2"
            };

            string serviceGroupName = "ServiceGroup2";
            ServiceGroupRepository serviceGroupRepository = new(_context);
            ServiceGroup actual = serviceGroupRepository.GetGroupByName(serviceGroupName);

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetGroupById()
        {
            _context.ChangeTracker.Clear();

            ServiceGroup expected = new ServiceGroup
            {
                Id = 2,
                Name = "ServiceGroup2"
            };

            int serviceGroupId = 2;
            ServiceGroupRepository serviceGroupRepository = new(_context);
            ServiceGroup actual = serviceGroupRepository.GetGroupById(serviceGroupId);

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<ServiceGroup> expected = new(){
                new ServiceGroup
                {
                    Id = 1,
                    Name = "ServiceGroup1"
                },
                new ServiceGroup
                {
                    Id = 2,
                    Name = "ServiceGroup2"
                },
                new ServiceGroup
                {
                    Id = 3,
                    Name = "ServiceGroup3"
                },
                new ServiceGroup
                {
                    Id = 4,
                    Name = "ServiceGroup4"
                }
            };

            ServiceGroup row = new ServiceGroup
            {
                Name = "ServiceGroup4"
            };

            ServiceGroupRepository serviceGroupRepository = new(_context);
            serviceGroupRepository.AddRow(row);
            List<ServiceGroup> actual = _context.ServiceGroups.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_UpdateRow()
        {
            _context.ChangeTracker.Clear();

			List<ServiceGroup> expected = new(){
				new ServiceGroup
                {
                    Id = 1,
                    Name = "ServiceGroup1"
                },
				new ServiceGroup
                {
                    Id = 2,
                    Name = "ServiceGroup4"
                },
				new ServiceGroup
                {
                    Id = 3,
                    Name = "ServiceGroup3"
                },
			};

			ServiceGroup updateRow = new ServiceGroup
            {
				Id = 2,
                Name = "ServiceGroup4"
            };

            ServiceGroupRepository serviceGroupRepository = new(_context);
			serviceGroupRepository.UpdateRow(updateRow);
            List<ServiceGroup> actual = _context.ServiceGroups.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

			List<ServiceGroup> expected = new(){
				new ServiceGroup
				{
					Id = 1,
                    Name = "ServiceGroup1"
                },
				new ServiceGroup
				{
					Id = 3,
                    Name = "ServiceGroup3"
                },
			};

			ServiceGroup row = new ServiceGroup
            {
				Id = 2,
                Name = "ServiceGroup2"
            };

            ServiceGroupRepository serviceGroupRepository = new(_context);
			serviceGroupRepository.DeleteRow(row);
            List<ServiceGroup> actual = _context.ServiceGroups.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}