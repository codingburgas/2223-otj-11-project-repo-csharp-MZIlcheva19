using bsm.dal.Data;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.dal.Repositories
{
    public class ServiceSkillRepository
    {
        private readonly BeautySalonContext _context;

        public ServiceSkillRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public IEnumerable<ServiceSkill> GetAll()
        {
            return _context.ServiceSkills;
        }

        public void DeleteRow(ServiceSkill serviceSkill)
        {
            if (serviceSkill != null)
            {
                _context.ServiceSkills.Remove(serviceSkill);
                _context.SaveChanges();
            }
        }
    }
}
