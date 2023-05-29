using bsm.bll;
using bsm.dal.Models;
using bsm.util;
using System.Text.RegularExpressions;

namespace bsm.console
{
    internal class SkillsEditMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Edit Skills");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetAll();

            if(skills == null)
            {
                Write.LineToCenter("No skills added");
            }
            else
            {
                foreach (Skill skill in skills)
                {
                    Write.LineToCenter(skill.Name);
                }
            }

            Console.WriteLine();
            Write.LineToCenter("[A] Add Skill   ");
            Write.LineToCenter("[E] Edit Skill  ");
            Write.LineToCenter("[D] Delete Skill");
            Write.LineToCenter("[B] Back        ");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'A': AddSkillMenu.Print(); break;
                    case 'E': EditSkillMenu.Print(); break;
                    case 'D': DeleteSkillMenu.Print(); break;
                    case 'B': AdminMenu.Print(); break;
                    default: AdminMenu.Print(); break;
                }
            };
        }
    }
}
