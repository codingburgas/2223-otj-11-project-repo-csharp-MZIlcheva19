using bsm.dal.Data;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.dal.Repositories
{
    public class SkillRepository
    {
        private readonly BeautySalonContext _context;

        public SkillRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public IEnumerable<Skill> GetAll()
        {
            return _context.Skills;
        }

        public Skill GetSkillByName(string name)
        {
            return _context.Skills.FirstOrDefault(x => x.Name.ToUpper() == name.ToUpper());
        }

        public void AddRow(Skill skill)
        {
            if (skill != null)
            {
                _context.Skills.Add(skill);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(Skill skill)
        {
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }
        }

        public void UpdateRow(Skill skill)
        {
            if (skill != null)
            {
                _context.Skills.Update(skill);
                _context.SaveChanges();
            }
        }
    }
}
