using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;

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
    }
}
