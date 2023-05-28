using bsm.console.UserMenus;

namespace bsm.console
{
    internal class AdminMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("[S] Edit Services  [K] Edit Skills  [U] Edit Users  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);  // Read a key from the console and convert it to uppercase

                switch (input)
                {
                    case 'S': ServiceGroupEditMenu.Print(); break;  // If the input is 'S', invoke the Print() method of ServiceGroupEditMenu
                    case 'K': SkillsEditMenu.Print(); break;  // If the input is 'K', invoke the Print() method of SkillsEditMenu
                    case 'U': UserAdminMenu.Print(); break;  // If the input is 'U', invoke the Print() method of UserAdminMenu
                    case 'B': MainMenu.Print(); break;  // If the input is 'B', invoke the Print() method of MainMenu
                    default: break;  // If the input doesn't match any of the cases, do nothing and continue the loop
                }
            }
        }
    }
}
