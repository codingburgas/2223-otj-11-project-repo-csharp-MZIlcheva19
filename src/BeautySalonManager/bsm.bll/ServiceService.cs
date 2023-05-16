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

        public static List<Service> GetAllByGroup(int groupId)
        {
            return GetAll().Where(s => s.GroupId == groupId).ToList();
        }

        public static void AddRow(string name, decimal price, TimeSpan time, int groupId)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new(context);

                Service service = new()
                {
                    Name = name,
                    Price = price,
                    Time = time,
                    GroupId = groupId
                };

                serviceRepository.AddRow(service);
            }
        }

        public static void DeleteAllByGroup(int groupId)
        {
            List<Service> services = GetAllByGroup(groupId);

            foreach (Service service in services)
            {
                ServiceSkillService.DeleteAllByService(service.Id);
            }
        }
    }
}
