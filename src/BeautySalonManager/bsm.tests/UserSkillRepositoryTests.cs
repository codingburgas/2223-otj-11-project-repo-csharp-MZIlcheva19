using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;

namespace wm.tests.Repositories
{
    public class UserSkillRepositoryTests
    {
        private BeautySalonContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.UserSkills.Add(new UserSkill
            {
                UserId = 1,
                SkillId = 1
            });
            _context.UserSkills.Add(new UserSkill
            {
                UserId = 1,
                SkillId = 2
            });
            _context.UserSkills.Add(new UserSkill
            {
                UserId = 2,
                SkillId = 1
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<UserSkill> expected = new(){
                new UserSkill
                {
                    Id = 1,
                    UserId = 1,
                    SkillId = 1
                },
                new UserSkill
                {
                    Id = 2,
                    UserId = 1,
                    SkillId = 2
                },
                new UserSkill
                {
                    Id = 3,
                    UserId = 2,
                    SkillId = 1
                }
            };

            UserSkillRepository userSkillRepository = new(_context);
            List<UserSkill> actual = userSkillRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetAllByUserId()
        {
            _context.ChangeTracker.Clear();

            List<UserSkill> expected = new(){
                new UserSkill
                {
                    Id = 1,
                    UserId = 1,
                    SkillId = 1
                },
                new UserSkill
                {
                    Id = 2,
                    UserId = 1,
                    SkillId = 2
                }
            };

            int userId = 1;
            UserSkillRepository userSkillRepository = new(_context);
            List<UserSkill> actual = userSkillRepository.GetAllByUserId(userId).ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetAllBySkillId()
        {
            _context.ChangeTracker.Clear();

            List<UserSkill> expected = new(){
                new UserSkill
                {
                    Id = 1,
                    UserId = 1,
                    SkillId = 1
                },
                new UserSkill
                {
                    Id = 3,
                    UserId = 2,
                    SkillId = 1
                }
            };

            int skillId = 1;
            UserSkillRepository userSkillRepository = new(_context);
            List<UserSkill> actual = userSkillRepository.GetAllBySkillId(skillId).ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<UserSkill> expected = new(){
                new UserSkill
                {
                    Id = 1,
                    UserId = 1,
                    SkillId = 1
                },
                new UserSkill
                {
                    Id = 2,
                    UserId = 1,
                    SkillId = 2
                },
                new UserSkill
                {
                    Id = 3,
                    UserId = 2,
                    SkillId = 1
                },
                new UserSkill
                {
                    Id = 4,
                    UserId = 2,
                    SkillId = 2
                }
            };

            UserSkill newRow = new UserSkill
            {
                UserId = 2,
                SkillId = 2
            };

            UserSkillRepository userSkillRepository = new(_context);
            userSkillRepository.AddRow(newRow);
            List<UserSkill> actual = _context.UserSkills.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<UserSkill> expected = new(){
                new UserSkill
                {
                    Id = 1,
                    UserId = 1,
                    SkillId = 1
                },
                new UserSkill
                {
                    Id = 3,
                    UserId = 2,
                    SkillId = 1
                }
            };

            UserSkill row = new UserSkill
            {
                Id = 2,
                UserId = 1,
                SkillId = 2
            };

            UserSkillRepository userSkillRepository = new(_context);
            userSkillRepository.DeleteRow(row);
            List<UserSkill> actual = _context.UserSkills.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}