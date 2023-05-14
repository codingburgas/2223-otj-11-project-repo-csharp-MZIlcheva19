using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;

namespace bsm.bll
{
    public class ServiceService
    {
        public static List<Service> GetAll()
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new(context);

                List<Service> services = serviceRepository.GetAll().ToList();

                return services;
            }
        }
    }
}
