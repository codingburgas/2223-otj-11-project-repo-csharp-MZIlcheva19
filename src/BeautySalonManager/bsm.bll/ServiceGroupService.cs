using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;

namespace bsm.bll
{
    public class ServiceGroupService
    {
        public static List<ServiceGroup> GetAll()
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new(context);

                List<ServiceGroup> groups = serviceGroupRepository.GetAll().ToList();

                return groups;
            }
        }
    }
}
