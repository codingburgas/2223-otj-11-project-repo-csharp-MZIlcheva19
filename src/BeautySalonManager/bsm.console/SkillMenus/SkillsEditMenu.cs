using bsm.bll;
using bsm.dal.Models;
using System.Text.RegularExpressions;

namespace bsm.console
{
    internal class SkillsEditMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Edit Skills");
            Console.WriteLine();

            List<Skill> skills = SkillService.GetAll();

            foreach (Skill skill in skills)
            {
                Console.WriteLine(skill.Name);
            }

            Console.WriteLine();
            Console.WriteLine("[A] Add Skill  [E] Edit Skill  [D] Delete Skill  [B] Back");

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
