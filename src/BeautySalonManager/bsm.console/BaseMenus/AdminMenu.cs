using bsm.util;

namespace bsm.console
{
    internal class AdminMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Admin Panel");
            Console.WriteLine();
            Write.LineToCenter("[S] Edit Services");
            Write.LineToCenter("[K] Edit Skills  ");
            Write.LineToCenter("[U] Edit Users   ");
            Write.LineToCenter("[B] Back         ");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'S': ServiceGroupEditMenu.Print(); break;
                    case 'K': SkillsEditMenu.Print(); break;
                    case 'U': UserAdminMenu.Print(); break;
                    case 'B': MainMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}
