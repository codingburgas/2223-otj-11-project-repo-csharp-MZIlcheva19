using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;

namespace wm.tests.Repositories
{
    public class SkillRepositoryTests
    {
        private BeautySalonContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.Skills.Add(new Skill
            {
                Name = "Skill1"
            });
            _context.Skills.Add(new Skill
            {
                Name = "Skill2"
            });
            _context.Skills.Add(new Skill
            {
                Name = "Skill3"
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<Skill> expected = new(){
                new Skill
                {
                    Id = 1,
                    Name = "Skill1"
                },
                new Skill
                {
                    Id = 2,
                    Name = "Skill2"
                },
                new Skill
                {
                    Id = 3,
                    Name = "Skill3"
                }
            };

            SkillRepository skillRepository = new(_context);
            List<Skill> actual = skillRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetSkillByName()
        {
            _context.ChangeTracker.Clear();

            Skill expected = new Skill
            {
                Id = 2,
                Name = "Skill2"
            };

            string skillName = "Skill2";
            SkillRepository skillRepository = new(_context);
            Skill actual = skillRepository.GetSkillByName(skillName);

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<Skill> expected = new(){
                new Skill
                {
                    Id = 1,
                    Name = "Skill1"
                },
                new Skill
                {
                    Id = 2,
                    Name = "Skill2"
                },
                new Skill
                {
                    Id = 3,
                    Name = "Skill3"
                },
                new Skill
                {
                    Id = 4,
                    Name = "Skill4"
                }
            };

            Skill row = new Skill
            {
                Name = "Skill4"
            };
            SkillRepository skillRepository = new(_context);
            skillRepository.AddRow(row);
            List<Skill> actual = _context.Skills.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_UpdateRow()
        {
            _context.ChangeTracker.Clear();

            List<Skill> expected = new(){
                new Skill
                {
                    Id = 1,
                    Name = "Skill1"
                },
                new Skill
                {
                    Id = 2,
                    Name = "Skill4"
                },
                new Skill
                {
                    Id = 3,
                    Name = "Skill3"
                }
            };

            Skill updateRow = new Skill
            {
                Id = 2,
                Name = "Skill4"
            };

            SkillRepository skillRepository = new(_context);
            skillRepository.UpdateRow(updateRow);
            List<Skill> actual = _context.Skills.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<Skill> expected = new(){
                new Skill
                {
                    Id = 1,
                    Name = "Skill1"
                },
                new Skill
                {
                    Id = 3,
                    Name = "Skill3"
                }
            };

            Skill row = new Skill
            {
                Id = 2,
                Name = "Skill2"
            };

            SkillRepository skillRepository = new(_context);
            skillRepository.DeleteRow(row);
            List<Skill> actual = _context.Skills.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}