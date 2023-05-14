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

        public ServiceGroup? GetGroupByName(string name)
        {
            return _context.ServiceGroups.SingleOrDefault(g => g.Name == name);
        }

        public void AddRow(ServiceGroup serviceGroup) 
        {
            if (serviceGroup != null)
            {
                _context.ServiceGroups.Add(serviceGroup);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(ServiceGroup serviceGroup)
        {
            if (serviceGroup != null)
            {
                _context.ServiceGroups.Remove(serviceGroup);
                _context.SaveChanges();
            }
        }
    }
}
