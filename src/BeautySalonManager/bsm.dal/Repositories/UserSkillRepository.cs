using bsm.dal.Data;
using bsm.dal.Models;

namespace bsm.dal.Repositories
{
    public class UserSkillRepository
    {
        private readonly BeautySalonContext _context;

        public UserSkillRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public IEnumerable<UserSkill> GetAll()
        {
            return _context.UserSkills;
        }

        public IEnumerable<UserSkill> GetAllByUserId(int userId)
        {
            IEnumerable<UserSkill> list = _context.UserSkills
                .Where(a => a.UserId == userId);

            return list;
        }

        public void AddRow(UserSkill userSkill)
        {
            if (userSkill != null)
            {
                _context.UserSkills.Add(userSkill);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(UserSkill userSkill)
        {
            if (userSkill != null)
            {
                _context.UserSkills.Remove(userSkill);
                _context.SaveChanges();
            }
        }
    }
}
