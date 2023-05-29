using bsm.dal.Data;
using bsm.dal.Models;
using bsm.dal.Repositories;

namespace bsm.bll
{
    public class SkillService
    {
        public static List<Skill> GetAll()
        {
            using (var context = new BeautySalonContext())
            {
                SkillRepository skillRepository = new(context);

                return skillRepository.GetAll().ToList();
            }
        }

        public static Skill GetSkillByName(string name)
        {
            using (var context = new BeautySalonContext())
            {
                SkillRepository skillRepository = new(context);

                return skillRepository.GetSkillByName(name);
            }
        }

        public static List<Skill> GetServicesSkills(int serviceId)
        {
            using (var context = new BeautySalonContext())
            {
                SkillRepository skillRepository = new(context);

                List<ServiceSkill> serviceSkills = ServiceSkillService.GetAllByServiceId(serviceId);
                List<Skill> skills = skillRepository.GetAll().ToList();
                List<Skill> result = new List<Skill>();

                foreach (Skill skill in skills)
                {
                    foreach (ServiceSkill serviceSkill in serviceSkills)
                    {
                        if (skill.Id == serviceSkill.SkillId)
                        {
                            result.Add(skill);
                            break;
                        }
                    }
                }

                return result;
            }
        }

        public static List<Skill> GetUsersSkills(int userId)
        {
            using (var context = new BeautySalonContext())
            {
                SkillRepository skillRepository = new(context);

                List<UserSkill> userSkills = UserSkillService.GetAllByUser(userId);
                List<Skill> skills = skillRepository.GetAll().ToList();
                List<Skill> result = new List<Skill>();

                foreach (Skill skill in skills)
                {
                    foreach (UserSkill userSkill in userSkills)
                    {
                        if (skill.Id == userSkill.SkillId)
                        {
                            result.Add(skill);
                            break;
                        }
                    }
                }

                return result;
            }
        }

        public static void AddRow(string name)
        {
            using (var context = new BeautySalonContext())
            {
                SkillRepository skillRepository = new(context);

                Skill skill = new Skill()
                {
                    Name = name
                };

                skillRepository.AddRow(skill);
            }
        }

        public static void DeleteSkill(string name)
        {
            using (var context = new BeautySalonContext())
            {
                SkillRepository skillRepository = new(context);

                Skill skill = skillRepository.GetSkillByName(name);
                UserSkillService.DeleteAllSkillsRows(skill);
                ServiceSkillService.DeleteAllBySkill(skill.Id);

                skillRepository.DeleteRow(skill);
            }
        }

        public static void EditRow(string oldName, string newName)
        {
            using (var context = new BeautySalonContext())
            {
                SkillRepository skillRepository = new(context);

                Skill skill = skillRepository.GetSkillByName(oldName);
                skill.Name = newName;

                skillRepository.UpdateRow(skill);
            }
        }
    }
}
