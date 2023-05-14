using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;

namespace bsm.bll
{
    public class UserSkillService
    {
        public static void RemoveUserSkills(User user)
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
    }
}
