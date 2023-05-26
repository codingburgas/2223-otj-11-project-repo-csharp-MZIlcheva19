using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;
using Microsoft.IdentityModel.Tokens;

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

        public static ServiceGroup? GetGroupByName(string name)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new(context);

                ServiceGroup? serviceGroup = serviceGroupRepository.GetGroupByName(name);

                return serviceGroup;
            }
        }

        public static int GetGroupIdByName(string name)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new(context);

                int serviceGroupId = serviceGroupRepository.GetGroupByName(name).Id;

                return serviceGroupId;
            }
        }

        public static string GetGroupNameById(int groupId)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new(context);

                string serviceGroupName = serviceGroupRepository.GetGroupById(groupId).Name;

                return serviceGroupName;
            }
        }

        public static void AddGroup(string name)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new(context);

                ServiceGroup serviceGroup = new();
                serviceGroup.Name = name;

                if(serviceGroup != null)
                {
                    serviceGroupRepository.AddRow(serviceGroup);
                }
            }
        }

        public static void EditGroup(string oldName, string newName)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new(context);

                ServiceGroup serviceGroup = GetGroupByName(oldName);
                serviceGroup.Name = newName;

                if(serviceGroup != null)
                {
                    serviceGroupRepository.UpdateRow(serviceGroup);
                }
            }
        }

        public static void DeleteGroup(string name)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceGroupRepository serviceGroupRepository = new(context);

                ServiceGroup? serviceGroup = GetGroupByName(name);

                if (serviceGroup != null)
                {
                    ServiceService.DeleteAllByGroup(serviceGroup.Id);
                    serviceGroupRepository.DeleteRow(serviceGroup);
                }
            }
        }

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
    }
}
