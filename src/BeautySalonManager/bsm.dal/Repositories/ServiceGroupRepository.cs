using bsm.dal.Data;
using bsm.dal.Models;

namespace bsm.dal.Repositories
{
    public class ServiceGroupRepository
    {
        private readonly BeautySalonContext _context;

        public ServiceGroupRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public IEnumerable<ServiceGroup> GetAll()
        {
            return _context.ServiceGroups;
        }
    }
}
