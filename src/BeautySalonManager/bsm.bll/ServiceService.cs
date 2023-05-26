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

        public static Service GetServiceById(int id)
        {
            return GetAll().FirstOrDefault(s => s.Id == id);
        }

        public static List<Service> GetAllByGroup(int groupId)
        {
            return GetAll().Where(s => s.GroupId == groupId).ToList();
        }

        public static Service? GetServiceByName(string name, int groupId)
        {
            Service? service = GetAll().FirstOrDefault(s => s.Name.ToUpper() == name.ToUpper() && s.GroupId == groupId);

            return service != null ? service : null;
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

        public static void EditRow(Service service, string name, decimal price, TimeSpan time)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new(context);

                service.Name = name;
                service.Price = price;
                service.Time = time;

                serviceRepository.UpdateRow(service);
            }
        }

        public static void DeleteRow(Service service)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new(context);

                serviceRepository.DeleteRow(service);
            }
        }

        public static void DeleteAllByGroup(int groupId)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new(context);
                List<Service> services = GetAllByGroup(groupId);

                foreach (Service service in services)
                {
                    ServiceSkillService.DeleteAllByService(service.Id);
                    serviceRepository.DeleteRow(service);
                }
            }
        }
    }
}
