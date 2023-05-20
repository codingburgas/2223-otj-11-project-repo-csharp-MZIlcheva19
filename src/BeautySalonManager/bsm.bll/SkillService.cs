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
