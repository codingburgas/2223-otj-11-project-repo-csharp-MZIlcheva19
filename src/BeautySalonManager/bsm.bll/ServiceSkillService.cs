using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;
using System.Text.RegularExpressions;

namespace bsm.bll
{
    public class ServiceSkillService
    {
        public static List<ServiceSkill> GetAll() 
        {
            using (var context = new BeautySalonContext())
            {
                ServiceSkillRepository serviceSkillRepository = new(context);

                List<ServiceSkill> serviceSkills = serviceSkillRepository.GetAll().ToList();

                return serviceSkills;
            }
        }

        public static List<ServiceSkill> GetAllByServiceId(int serviceId)
        {
            List<ServiceSkill> serviceSkills = GetAll().Where(s => s.ServiceId == serviceId).ToList();
            return serviceSkills;
        }

        public static List<ServiceSkill> GetAllBySkillId(int skillId)
        {
            List<ServiceSkill> serviceSkills = GetAll().Where(s => s.SkillId == skillId).ToList();
            return serviceSkills;
        }

        public static void AddServiceSkill(int groupId, string serviceName, string skillName)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceSkillRepository serviceSkillRepository = new(context);

                Service service = ServiceService.GetServiceByName(serviceName, groupId);
                Skill skill = SkillService.GetSkillByName(skillName);

                ServiceSkill serviceSkill = new ServiceSkill()
                {
                    ServiceId = service.Id,
                    SkillId = skill.Id
                };

                serviceSkillRepository.AddRow(serviceSkill);
            }
        }

        public static void RemoveServiceSkill(int groupId, string serviceName, string skillName)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceSkillRepository serviceSkillRepository = new(context);

                Service service = ServiceService.GetServiceByName(serviceName, groupId);
                Skill skill = SkillService.GetSkillByName(skillName);

                ServiceSkill serviceSkill = GetAllByServiceId(service.Id).FirstOrDefault(ss => ss.SkillId == skill.Id);

                serviceSkillRepository.DeleteRow(serviceSkill);
            }
        }

        public static void DeleteAllByService(int serviceId)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceSkillRepository serviceSkillRepository = new(context);

                List<ServiceSkill> serviceSkills = GetAllByServiceId(serviceId);

                foreach (var serviceSkill in serviceSkills)
                {
                    serviceSkillRepository.DeleteRow(serviceSkill);
                }
            }
        }

        public static void DeleteAllBySkill(int skillId)
        {
            using (var context = new BeautySalonContext())
            {
                ServiceSkillRepository serviceSkillRepository = new(context);

                List<ServiceSkill> serviceSkills = GetAllBySkillId(skillId);

                foreach (var serviceSkill in serviceSkills)
                {
                    serviceSkillRepository.DeleteRow(serviceSkill);
                }
            }
        }
    }
}
