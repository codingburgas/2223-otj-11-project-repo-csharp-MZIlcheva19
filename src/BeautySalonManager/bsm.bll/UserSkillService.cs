using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;

namespace bsm.bll
{
    public class UserSkillService
    {
        public static List<UserSkill> GetAllByUser(int userId)
        {
            using (var context = new BeautySalonContext())
            {
                UserSkillRepository userSkillRepository = new(context);

                return userSkillRepository.GetAllByUserId(userId).ToList();
            }
        }

        public static void AddSkillToUser(User user, string skillName)
        {
            using (var context = new BeautySalonContext())
            {
                UserSkillRepository userSkillRepository = new(context);

                Skill skill = SkillService.GetSkillByName(skillName);

                UserSkill userSkill = new UserSkill()
                {
                    UserId = user.Id,
                    SkillId = skill.Id
                };

                if(!UserSkillExists(userSkill))
                {
                    userSkillRepository.AddRow(userSkill);
                }
            }
        }

        public static void RemoveSkill(User user, string skillName)
        {
            using (var context = new BeautySalonContext())
            {
                UserSkillRepository userSkillRepository = new(context);

                Skill skill = SkillService.GetSkillByName(skillName);

                UserSkill userSkill = userSkillRepository.GetAll().FirstOrDefault(us => us.UserId == user.Id && us.SkillId == skill.Id);

                userSkillRepository.DeleteRow(userSkill);
            }
        }

        public static void DeleteAllUsersSkills(User user)
        {
            using (var context = new BeautySalonContext())
            {
                UserSkillRepository userSkillRepository = new(context);

                List<UserSkill> userSkills = userSkillRepository.GetAllByUserId(user.Id).ToList();

                foreach (UserSkill userSkill in userSkills)
                {
                    userSkillRepository.DeleteRow(userSkill);
                }
            }
        }

        public static bool UserSkillExists(UserSkill userSkill)
        {
            using (var context = new BeautySalonContext())
            {
                UserSkillRepository userSkillRepository = new(context);

                List<UserSkill> userSkillsList = userSkillRepository.GetAll().ToList();

                if(userSkillsList.FirstOrDefault(us => us.UserId == userSkill.UserId && us.SkillId == userSkill.SkillId) ==  null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
