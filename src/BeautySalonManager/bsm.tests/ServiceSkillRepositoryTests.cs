using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;

namespace wm.tests.Repositories
{
    public class ServiceSkillRepositoryTests
    {
        private BeautySalonContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.ServiceSkills.Add(new ServiceSkill
            {
                ServiceId = 1,
                SkillId = 1
            });
            _context.ServiceSkills.Add(new ServiceSkill
            {
                ServiceId = 1,
                SkillId = 2
            });
            _context.ServiceSkills.Add(new ServiceSkill
            {
                ServiceId = 2,
                SkillId = 1
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<ServiceSkill> expected = new(){
                new ServiceSkill
                {
                    Id = 1,
                    ServiceId = 1,
                    SkillId = 1
                },
                new ServiceSkill
                {
                    Id = 2,
                    ServiceId = 1,
                    SkillId = 2
                },
                new ServiceSkill
                {
                    Id = 3,
                    ServiceId = 2,
                    SkillId = 1
                }
            };

            ServiceSkillRepository serviceSkillRepository = new(_context);
            List<ServiceSkill> actual = serviceSkillRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<ServiceSkill> expected = new(){
                new ServiceSkill
                {
                    Id = 1,
                    ServiceId = 1,
                    SkillId = 1
                },
                new ServiceSkill
                {
                    Id = 2,
                    ServiceId = 1,
                    SkillId = 2
                },
                new ServiceSkill
                {
                    Id = 3,
                    ServiceId = 2,
                    SkillId = 1
                },
                new ServiceSkill
                {
                    Id = 4,
                    ServiceId = 2,
                    SkillId = 2
                }
            };

            ServiceSkill newRow = new ServiceSkill
            {
                ServiceId = 2,
                SkillId = 2
            };

            ServiceSkillRepository serviceSkillRepository = new(_context);
            serviceSkillRepository.AddRow(newRow);
            List<ServiceSkill> actual = _context.ServiceSkills.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<ServiceSkill> expected = new(){
                new ServiceSkill
                {
                    Id = 1,
                    ServiceId = 1,
                    SkillId = 1
                },
                new ServiceSkill
                {
                    Id = 3,
                    ServiceId = 2,
                    SkillId = 1
                }
            };

            ServiceSkill row = new ServiceSkill
            {
                Id = 2,
                ServiceId = 1,
                SkillId = 2
            };

            ServiceSkillRepository serviceSkillRepository = new(_context);
            serviceSkillRepository.DeleteRow(row);
            List<ServiceSkill> actual = _context.ServiceSkills.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}
