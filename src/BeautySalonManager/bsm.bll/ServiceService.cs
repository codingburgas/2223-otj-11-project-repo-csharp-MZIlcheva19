using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;
using Microsoft.IdentityModel.Tokens;

namespace bsm.bll
{
    public class ServiceService
    {
        // Retrieves all services
        public static List<Service> GetAll()
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new ServiceRepository(context);

                List<Service> services = serviceRepository.GetAll().ToList();

                return services;
            }
        }

        // Retrieves a service by its ID
        public static Service GetServiceById(int id)
        {
            return GetAll().FirstOrDefault(s => s.Id == id);
        }

        // Retrieves all services by group ID
        public static List<Service> GetAllByGroup(int groupId)
        {
            return GetAll().Where(s => s.GroupId == groupId).ToList();
        }

        // Retrieves a service by its name and group ID
        public static Service? GetServiceByName(string name, int groupId)
        {
            Service? service = GetAll().FirstOrDefault(s => s.Name.ToUpper() == name.ToUpper() && s.GroupId == groupId);

            return service != null ? service : null;
        }

        // Adds a new service
        public static void AddRow(string name, decimal price, TimeSpan time, int groupId)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new ServiceRepository(context);

                Service service = new Service()
                {
                    Name = name,
                    Price = price,
                    Time = time,
                    GroupId = groupId
                };

                serviceRepository.AddRow(service);
            }
        }

        // Edits an existing service
        public static void EditRow(Service service, string name, decimal price, TimeSpan time)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new ServiceRepository(context);

                service.Name = name;
                service.Price = price;
                service.Time = time;

                serviceRepository.UpdateRow(service);
            }
        }

        // Deletes a service
        public static void DeleteRow(Service service)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new ServiceRepository(context);

                serviceRepository.DeleteRow(service);
            }
        }

        // Deletes all services associated with a group
        public static void DeleteAllByGroup(int groupId)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceRepository serviceRepository = new ServiceRepository(context);
                List<Service> services = GetAllByGroup(groupId);

                foreach (Service service in services)
                {
                    ServiceSkillService.DeleteAllByService(service.Id);
                    serviceRepository.DeleteRow(service);
                }
            }
        }

        // Checks if a name is valid
        public static int CheckName(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return 0;  
            }
            if (name.Any(c => Char.IsDigit(c)))
            {
                return 1;  
            }
            return -1; 
        }

        // Checks if a price is valid
        public static int CheckPrice(string price)
        {
            if (price.IsNullOrEmpty())
            {
                return 0;  
            }
            if (price.Any(c => Char.IsLetter(c)))
            {
                return 1;  
            }
            return -1;  
        }

        // Checks if a time is valid
        public static int CheckTime(string time)
        {
            if (time.IsNullOrEmpty())
            {
                return 0;  
            }
            if (time.Any(c => Char.IsLetter(c)))
            {
                return 1;  
            }
            return -1; 
        }
    }
}
