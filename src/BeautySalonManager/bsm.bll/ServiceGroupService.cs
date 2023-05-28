using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;
using Microsoft.IdentityModel.Tokens;

namespace bsm.bll
{
    public class ServiceGroupService
    {
        // Retrieves all service groups
        public static List<ServiceGroup> GetAll()
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new ServiceGroupRepository(context);

                List<ServiceGroup> groups = serviceGroupRepository.GetAll().ToList();

                return groups;
            }
        }

        // Retrieves a service group by its name
        public static ServiceGroup? GetGroupByName(string name)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new ServiceGroupRepository(context);

                ServiceGroup? serviceGroup = serviceGroupRepository.GetGroupByName(name);

                return serviceGroup;
            }
        }

        // Retrieves the ID of a service group by its name
        public static int GetGroupIdByName(string name)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new ServiceGroupRepository(context);

                int serviceGroupId = serviceGroupRepository.GetGroupByName(name).Id;

                return serviceGroupId;
            }
        }

        // Retrieves the name of a service group by its ID
        public static string GetGroupNameById(int groupId)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new ServiceGroupRepository(context);

                string serviceGroupName = serviceGroupRepository.GetGroupById(groupId).Name;

                return serviceGroupName;
            }
        }

        // Adds a new service group
        public static void AddGroup(string name)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new ServiceGroupRepository(context);

                ServiceGroup serviceGroup = new ServiceGroup();
                serviceGroup.Name = name;

                if (serviceGroup != null)
                {
                    serviceGroupRepository.AddRow(serviceGroup);
                }
            }
        }

        // Edits an existing service group
        public static void EditGroup(string oldName, string newName)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new ServiceGroupRepository(context);

                ServiceGroup serviceGroup = GetGroupByName(oldName);
                serviceGroup.Name = newName;

                if (serviceGroup != null)
                {
                    serviceGroupRepository.UpdateRow(serviceGroup);
                }
            }
        }

        // Deletes a service group and its associated services
        public static void DeleteGroup(string name)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new ServiceGroupRepository(context);

                ServiceGroup? serviceGroup = GetGroupByName(name);

                if (serviceGroup != null)
                {
                    ServiceService.DeleteAllByGroup(serviceGroup.Id);
                    serviceGroupRepository.DeleteRow(serviceGroup);
                }
            }
        }

        // Checks if a name is valid
        public static int CheckName(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return 0;  // Returning 0 to indicate an empty name
            }
            if (name.Any(c => Char.IsDigit(c)))
            {
                return 1;  // Returning 1 to indicate a name with digits
            }
            return -1;  // Returning -1 to indicate a valid name
        }
    }
}
