using bsm.console.UserMenus;

namespace bsm.console
{
    internal class AdminMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("[S] Services  [K] Skills  [U] Users  [B] Back");

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
